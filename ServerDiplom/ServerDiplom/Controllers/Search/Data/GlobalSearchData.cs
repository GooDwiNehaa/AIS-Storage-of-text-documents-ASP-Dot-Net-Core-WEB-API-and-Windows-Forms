using System.Collections.Generic;

namespace ServerDiplom.Controllers.Search.Data
{
    public class GlobalSearchData
    {
        public string DocumentName { get; set; }
        public string X { get; set; }
        public List<int> ListFoundMatches { get; set; }
        public int CountSymbolsDoc { get; set; }
    }
}
