using System.Collections.Generic;

namespace ClientDiplom.Data
{
    public class DocumentEditData
    {
        public string DocumentOldName { get; set; }
        public string DocumentNewName { get; set; }
        public List<string> Categories { get; set; } = new List<string>();
        public string DocumentContent { get; set; }
    }
}
