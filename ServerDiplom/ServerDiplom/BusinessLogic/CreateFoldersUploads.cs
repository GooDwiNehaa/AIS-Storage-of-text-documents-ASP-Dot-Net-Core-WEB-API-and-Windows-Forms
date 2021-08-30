using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ServerDiplom.BusinessLogic
{
    public class CreateFoldersUploads
    {
        private readonly IWebHostEnvironment _appEnvironment;

        public CreateFoldersUploads(IWebHostEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
        }

        public void CreateFolders()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(_appEnvironment.ContentRootPath + "/Uploads");
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
        }
    }
}
