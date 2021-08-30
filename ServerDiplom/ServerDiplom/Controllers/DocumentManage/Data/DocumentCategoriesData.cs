using System.Collections.Generic;

namespace ServerDiplom.Controllers.DocumentManage.Data
{
    public class DocumentCategoriesData
    {
        public string DocumentName { get; set; }
        public List<string> Categories { get; set; }
        public byte[] DocumentFile { get; set; }
    }
}
