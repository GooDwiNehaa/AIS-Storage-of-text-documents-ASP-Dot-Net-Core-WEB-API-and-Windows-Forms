using System.Collections.Generic;

namespace ServerDiplom.Controllers.DocumentManage.Data
{
    public class DocumentEditData
    {
        public string DocumentOldName { get; set; }
        public string DocumentNewName { get; set; }
        public List<string> Categories { get; set; }
        public string DocumentContent { get; set; }
    }
}
