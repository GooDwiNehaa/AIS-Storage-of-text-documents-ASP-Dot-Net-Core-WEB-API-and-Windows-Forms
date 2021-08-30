using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.BusinessLogic;
using ServerDiplom.Controllers.Search.Data;
using ServerDiplom.Models;

namespace ServerDiplom.Controllers.Search
{
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly string _path;
        private readonly ReadWriteDocs _readWriteDocs;
        public SearchController(ApplicationContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _appEnvironment = appEnvironment;
            _path = _appEnvironment.ContentRootPath + "/Uploads/";
            _readWriteDocs = new ReadWriteDocs();
        }

        [Route("single-search")]
        [HttpPost]
        public async Task<List<int>> SingleSearch([FromBody] SearchData searchData)
        {
            SearchAlgorithms searchAlgorithms = new SearchAlgorithms();

            ResultAlgorithm resultAlg = new ResultAlgorithm();

            await Search(searchAlgorithms, resultAlg, searchData);

            return resultAlg.ListOfFoundMatches;
        }

        [Route("global-search")]
        [HttpPost]
        public async Task<List<GlobalSearchData>> GlobalSearch([FromBody] SearchData searchData)
        {
            List<GlobalSearchData> listGSD = new List<GlobalSearchData>();

            SearchAlgorithms searchAlgorithms = new SearchAlgorithms();

            ResultAlgorithm resultAlg = new ResultAlgorithm();

            DirectoryInfo dirInfo = new DirectoryInfo(_path);

            CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

            var allCateg = await _db.Categories.FirstOrDefaultAsync(c => c.Id == 1);

            var all = searchData.Categories.Contains(allCateg.Name);

            if (all == true)
            {
                foreach (var dir in dirInfo.GetFiles())
                {
                    if (CancelToken.CancelTokenSourceGS.Token.IsCancellationRequested)
                    {
                        CancelToken.CancelTokenSourceGS.Dispose();
                        CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

                        return null;
                    }

                    await GSearch(listGSD, searchAlgorithms, resultAlg, searchData, dir.Name, dir.FullName);

                    resultAlg = null;
                    resultAlg = new ResultAlgorithm();
                }
            }
            else
            {
                var documents = await _db.DocumentCategory
                    .Where(dc => searchData.Categories.Contains(dc.Category.Name))
                    .Select(dc => dc.Document)
                    .Distinct()
                    .ToListAsync();

                for (int i = 0; i < documents.Count; i++)
                {
                    if (CancelToken.CancelTokenSourceGS.Token.IsCancellationRequested)
                    {
                        CancelToken.CancelTokenSourceGS.Dispose();
                        CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

                        return null;
                    }

                    foreach (var dir in dirInfo.GetFiles())
                    {
                        if (CancelToken.CancelTokenSourceGS.Token.IsCancellationRequested)
                        {
                            CancelToken.CancelTokenSourceGS.Dispose();
                            CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

                            return null;
                        }

                        if (documents[i].Name == dir.Name)
                        {
                            if (CancelToken.CancelTokenSourceGS.Token.IsCancellationRequested)
                            {
                                CancelToken.CancelTokenSourceGS.Dispose();
                                CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

                                return null;
                            }

                            await GSearch(listGSD, searchAlgorithms, resultAlg, searchData, dir.Name, dir.FullName);

                            resultAlg = null;
                            resultAlg = new ResultAlgorithm();

                            break;
                        }
                    }
                }
            }

            if (CancelToken.CancelTokenSourceGS.Token.IsCancellationRequested)
            {
                CancelToken.CancelTokenSourceGS.Dispose();
                CancelToken.CancelTokenSourceGS = new CancellationTokenSource();

                return null;
            }

            return listGSD.OrderByDescending(l => l.ListFoundMatches.Count).ToList();
        }

        [Route("research")]
        [HttpPost]
        public async Task<AlgorithmsChartData> Research([FromBody] ResearchSourceData sourceData)
        {
            SearchAlgorithmsWorker searchAlgorithmsWorker = new SearchAlgorithmsWorker();

            List<ResultAlgorithmsData> resultAlgorithmsDataList = new List<ResultAlgorithmsData>();

            ResultAlgorithmsData resultAlgorithmsData = new ResultAlgorithmsData();

            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == sourceData.DocumentName);

            var text = await _readWriteDocs.DocumentFormatReading(document.Name, document.Path);

            CancelToken.CancelTokenSourceR = new CancellationTokenSource();

            for (int i = 0; i < 100; i++)
            {
                if (CancelToken.CancelTokenSourceR.Token.IsCancellationRequested)
                {
                    CancelToken.CancelTokenSourceR.Dispose();
                    CancelToken.CancelTokenSourceR = new CancellationTokenSource();

                    return new AlgorithmsChartData();
                }

                await searchAlgorithmsWorker.LaunchingSearchAlgorithms(sourceData.Row.ToLower(), text.ToLower(), resultAlgorithmsData);

                resultAlgorithmsDataList.Add(resultAlgorithmsData);

                resultAlgorithmsData = null;
                resultAlgorithmsData = new ResultAlgorithmsData();
            }

            var bfStrTime = resultAlgorithmsDataList.Select(r => r.BruteForce.Timer).ToList();
            var rkStrTime = resultAlgorithmsDataList.Select(r => r.RK.Timer).ToList();
            var kmpStrTime = resultAlgorithmsDataList.Select(r => r.KMPWithPFunc.Timer).ToList();
            var algZStrTime = resultAlgorithmsDataList.Select(r => r.AlgZ.Timer).ToList();
            var bmhStrTime = resultAlgorithmsDataList.Select(r => r.BMH.Timer).ToList();

            var bfTime = new List<int>();
            var rkTime = new List<int>();
            var kmpTime = new List<int>();
            var algZTime = new List<int>();
            var bmhTime = new List<int>();

            for (int i = 0; i < bfStrTime.Count; i++)
            {
                if (CancelToken.CancelTokenSourceR.Token.IsCancellationRequested)
                {
                    CancelToken.CancelTokenSourceR.Dispose();
                    CancelToken.CancelTokenSourceR = new CancellationTokenSource();

                    return new AlgorithmsChartData();
                }

                bfTime.Add(GetMillisecond(bfStrTime[i]));
                rkTime.Add(GetMillisecond(rkStrTime[i]));
                kmpTime.Add(GetMillisecond(kmpStrTime[i]));
                algZTime.Add(GetMillisecond(algZStrTime[i]));
                bmhTime.Add(GetMillisecond(bmhStrTime[i]));
            }

            AlgorithmsChartData algorithmsChartData = new AlgorithmsChartData
            {
                BF = new ChartData
                {
                    AlgorithmName = resultAlgorithmsDataList[0].BruteForce.AlgorithmName,
                    Time = bfTime.Average(),
                    CountMatches = resultAlgorithmsDataList[0].BruteForce.ListOfFoundMatches.Count
                },
                RK = new ChartData()
                {
                    AlgorithmName = resultAlgorithmsDataList[0].RK.AlgorithmName,
                    Time = rkTime.Average(),
                    CountMatches = resultAlgorithmsDataList[0].RK.ListOfFoundMatches.Count
                },
                KMP = new ChartData()
                {
                    AlgorithmName = resultAlgorithmsDataList[0].KMPWithPFunc.AlgorithmName,
                    Time = kmpTime.Average(),
                    CountMatches = resultAlgorithmsDataList[0].KMPWithPFunc.ListOfFoundMatches.Count
                },
                AlgZ = new ChartData()
                {
                    AlgorithmName = resultAlgorithmsDataList[0].AlgZ.AlgorithmName,
                    Time = algZTime.Average(),
                    CountMatches = resultAlgorithmsDataList[0].AlgZ.ListOfFoundMatches.Count
                },
                BHM = new ChartData()
                {
                    AlgorithmName = resultAlgorithmsDataList[0].BMH.AlgorithmName,
                    Time = bmhTime.Average(),
                    CountMatches = resultAlgorithmsDataList[0].BMH.ListOfFoundMatches.Count
                }
            };

            if (CancelToken.CancelTokenSourceR.Token.IsCancellationRequested)
            {
                CancelToken.CancelTokenSourceR.Dispose();
                CancelToken.CancelTokenSourceR = new CancellationTokenSource();

                return new AlgorithmsChartData();
            }

            return algorithmsChartData;
        }

        [Route("cancel/{method}")]
        [HttpGet]
        public async Task CancelMethod([FromQuery] string method)
        {
            switch (method)
            {
                case "research":
                    await Task.Run(() => CancelToken.CancelTokenSourceR.Cancel());
                    break;
                case "global-search":
                    await Task.Run(() => CancelToken.CancelTokenSourceGS.Cancel());
                    break;
                default:
                    break;
            }
        }

        private async Task Search(SearchAlgorithms searchAlgorithms, ResultAlgorithm resultAlg, SearchData searchData)
        {
            if (searchData.X.Length < 5)
            {
                await Task.Run(() => searchAlgorithms.KMPWithPFuncTime(searchData.X.ToLower(), searchData.S.ToLower(), resultAlg));
            }
            else
            {
                await Task.Run(() => searchAlgorithms.BMHTime(searchData.X.ToLower(), searchData.S.ToLower(), resultAlg));
            }
        }

        private async Task GSearch(List<GlobalSearchData> listGSD, SearchAlgorithms searchAlgorithms, ResultAlgorithm resultAlg, SearchData searchData, string name, string path)
        {
            searchData.S = await _readWriteDocs.DocumentFormatReading(name, path);

            searchData.S = DelCarret(searchData.S);

            await Search(searchAlgorithms, resultAlg, searchData);

            int count = resultAlg.ListOfFoundMatches.Count;

            if (count > 0)
            {
                listGSD.Add(new GlobalSearchData
                {
                    DocumentName = name,
                    X = searchData.X,
                    ListFoundMatches = resultAlg.ListOfFoundMatches,
                    CountSymbolsDoc = searchData.S.Length
                });
            }
        }

        public static string DelCarret(string myString)
        {
            Regex re = new Regex("\r\n");
            return re.Replace(myString, "\n");
        }

        private int GetMillisecond(string time)
        {
            int idx = time.IndexOf(".") + 1;
            int result = Convert.ToInt32(time.Substring(idx));
            return result;
        }
    }
}
