using System.Collections.Generic;

namespace ClientDiplom.Data
{
    public class SearchData
    {
        public string X { get; set; }
        public string S { get; set; }
        public List<string> DocumentNames { get; set; } = new List<string>();
        public List<string> Categories { get; set; }
        public List<string> DocumentsContent { get; set; } = new List<string>();
    }
}
