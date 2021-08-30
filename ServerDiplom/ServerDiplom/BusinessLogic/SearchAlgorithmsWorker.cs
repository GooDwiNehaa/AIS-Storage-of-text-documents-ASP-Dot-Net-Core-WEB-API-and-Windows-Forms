using System.Threading.Tasks;
using ServerDiplom.Controllers.Search.Data;

namespace ServerDiplom.BusinessLogic
{
    public class SearchAlgorithmsWorker
    {
        private SearchAlgorithms searchAlgorithms = new SearchAlgorithms();

        public async Task LaunchingSearchAlgorithms(string x, string s, ResultAlgorithmsData resultAlgorithmsData)
        {
            Task aTimeBruteForce = Task.Run(() => searchAlgorithms.BrutForceTime(x, s, resultAlgorithmsData.BruteForce));
            Task aTimeRK = Task.Run(() => searchAlgorithms.RabinaKarpaTime(x, s, resultAlgorithmsData.RK));
            Task aTimeKMPWithPFunc = Task.Run(() => searchAlgorithms.KMPWithPFuncTime(x, s, resultAlgorithmsData.KMPWithPFunc));
            Task aTimeKMPWithZFunc = Task.Run(() => searchAlgorithms.ZAlgorithmTime(x, s, resultAlgorithmsData.AlgZ));
            Task aTimeBMH = Task.Run(() => searchAlgorithms.BMHTime(x, s, resultAlgorithmsData.BMH));

            await Task.WhenAll(new[] 
            {
                aTimeBruteForce,
                aTimeRK,
                aTimeKMPWithPFunc,
                aTimeKMPWithZFunc,
                aTimeBMH,
            });

            aTimeBruteForce.Dispose();
            aTimeRK.Dispose();
            aTimeKMPWithPFunc.Dispose();
            aTimeKMPWithZFunc.Dispose();
            aTimeBMH.Dispose();
        }
    }
}
