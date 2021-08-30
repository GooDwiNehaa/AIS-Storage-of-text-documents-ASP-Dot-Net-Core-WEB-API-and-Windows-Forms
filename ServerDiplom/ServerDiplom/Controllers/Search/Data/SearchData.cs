using System.Collections.Generic;

namespace ServerDiplom.Controllers.Search.Data
{
    public class SearchData
    {
        public string X { get; set; }
        public string S { get; set; }
        public List<string> DocumentNames { get; set; }
        public List<string> Categories { get; set; }
        public List<string> DocumentsContent { get; set; }
    }
}
