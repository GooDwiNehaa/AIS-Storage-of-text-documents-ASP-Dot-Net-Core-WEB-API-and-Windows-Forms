using System;
using System.Collections.Generic;
using IO = System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.Models;
using ServerDiplom.Controllers.DocumentManage.Data;
using System.IO;
using ServerDiplom.BusinessLogic;
using ServerDiplom.Controllers.Search;

namespace ServerDiplom.Controllers.DocumentManage
{
    [ApiController]
    public class DocumentManageController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly string _path;
        private readonly ReadWriteDocs _readWriteDocs;

        public DocumentManageController(ApplicationContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _appEnvironment = appEnvironment;
            _path = _appEnvironment.ContentRootPath + "/Uploads/";
            _readWriteDocs = new ReadWriteDocs();
        }

        [Route("add-document")]
        [HttpPost]
        public async Task AddDocument([FromBody] DocumentCategoriesData documentCategories)
        {
            string documentName = documentCategories.DocumentName;
            string documentPath = $"{_path}{documentName}";

            var documentFile = documentCategories.DocumentFile;

            using (var fileStream = new IO.FileStream(documentPath, IO.FileMode.Create, IO.FileAccess.Write))
            {
                await fileStream.WriteAsync(documentFile, 0, documentFile.Length);
            }

            var categories = await _db.Categories.ToListAsync();

            List<int> categoriesId = new List<int>();
            
            for (int i = 0; i < documentCategories.Categories.Count; i++)
            {
                for (int j = 0; j < categories.Count; j++)
                {
                    if (documentCategories.Categories[i] == categories[j].Name)
                    {
                        categoriesId.Add(categories[j].Id);
                    }
                }
            }

            Document document = new Document
            {
                Name = documentName,
                Path = documentPath
            };

            _db.Documents.Add(document);
            await _db.SaveChangesAsync();

            List<DocumentCategory> documentCategoryList = new List<DocumentCategory>();

            for (int i = 0; i < categoriesId.Count; i++)
            {
                documentCategoryList.Add(new DocumentCategory 
                {
                    Document = document,
                    CategoryId = categoriesId[i]
                });
            }

            _db.DocumentCategory.AddRange(documentCategoryList);

            await _db.SaveChangesAsync();
        }

        [Route("show-all-documents")]
        [HttpPost]
        public async Task<List<string>> ShowAllDocuments([FromBody] List<string> categories)
        {
            List<string> documentsNames;

            var allCategories = await _db.Categories.FirstOrDefaultAsync(c => c.Id == 1);

            if (categories.Contains(allCategories.Name))
            {
                documentsNames = await _db.Documents
                    .Select(d => d.Name)
                    .ToListAsync();
            }
            else
            {
                documentsNames = await _db.DocumentCategory
                    .Where(dc => categories.Contains(dc.Category.Name))
                    .Select(dc => dc.Document.Name)
                    .Distinct()
                    .ToListAsync();
            }

            return documentsNames;
        }

        [Route("del-document/{documentName}")]
        [HttpDelete]
        public async Task DelDocument([FromRoute] string documentName)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == documentName);

            _db.Documents.Remove(document);
            await _db.SaveChangesAsync();

            DirectoryInfo dirInfo = new DirectoryInfo(_path);

            foreach (var dir in dirInfo.GetFiles())
            {
                if (documentName == dir.Name)
                {
                    dir.Delete();
                }
            }
        }

        [Route("get-document-content")]
        [HttpPost]
        public async Task<string> GetDocumentContent([FromBody] string documentName)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == documentName);

            var documentContent = await _readWriteDocs.DocumentFormatReading(document.Name, document.Path);

            return documentContent;
        }

        [Route("edit-document")]
        [HttpPut]
        public async Task EditDocument([FromBody] DocumentEditData documentEditData)
        {
            var documentNewPath = $"{_path}{documentEditData.DocumentNewName}";

            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == documentEditData.DocumentOldName);

            IO.File.Move(document.Path, documentNewPath);

            await _readWriteDocs.DocumentFormatReWriting
            (
                documentEditData.DocumentNewName,
                documentNewPath,
                documentEditData.DocumentContent
            );

            document.Name = documentEditData.DocumentNewName;
            document.Path = documentNewPath;

            await _db.SaveChangesAsync();

            var documentCategory = await _db.DocumentCategory
                .Where(dc => dc.DocumentId == document.Id)
                .ToListAsync();

            _db.DocumentCategory.RemoveRange(documentCategory);

            await _db.SaveChangesAsync();

            var checkedCategories = documentEditData.Categories;

            List<DocumentCategory> documentCategoryList = new List<DocumentCategory>();

            List<int> categoriesId = new List<int>();

            var categories = await _db.Categories.ToListAsync();

            for (int i = 0; i < checkedCategories.Count; i++)
            {
                for (int j = 0; j < categories.Count; j++)
                {
                    if (checkedCategories[i] == categories[j].Name)
                    {
                        categoriesId.Add(categories[j].Id);
                    }
                }
            }

            for (int i = 0; i < categoriesId.Count; i++)
            {
                documentCategoryList.Add(new DocumentCategory
                {
                    Document = document,
                    CategoryId = categoriesId[i]
                });
            }

            _db.DocumentCategory.AddRange(documentCategoryList);

            await _db.SaveChangesAsync();
        }

        [Route("download-document")]
        [HttpPost]
        public async Task<byte[]> DownloadDocument([FromBody] string documentName)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == documentName);

            var documentBytes = IO.File.ReadAllBytes(document.Path);

            return documentBytes;
        }

        [Route("get-count-symbols-document")]
        [HttpPost]
        public async Task<int> GetCountSymbolsDocument([FromBody] string documentName)
        {
            var document = await _db.Documents.FirstOrDefaultAsync(d => d.Name == documentName);

            string content = await _readWriteDocs.DocumentFormatReading(document.Name, document.Path);

            return SearchController.DelCarret(content).Length;
        }
    }
}
