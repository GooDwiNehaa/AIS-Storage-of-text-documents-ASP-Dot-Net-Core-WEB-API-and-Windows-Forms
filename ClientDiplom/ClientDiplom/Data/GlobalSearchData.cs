using System.Collections.Generic;

namespace ClientDiplom.Data
{
    public class GlobalSearchData
    {
        public string DocumentName { get; set; }
        public string X { get; set; }
        public List<int> ListFoundMatches { get; set; }
        public int CountSymbolsDoc{ get; set; }
    }
}
