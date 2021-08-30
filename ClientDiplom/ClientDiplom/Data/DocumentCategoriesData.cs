using System.Collections.Generic;

namespace ClientDiplom.Data
{
    public class DocumentCategoriesData
    {
        public string DocumentName { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public byte[] DocumentFile { get; set; }
    }
}
