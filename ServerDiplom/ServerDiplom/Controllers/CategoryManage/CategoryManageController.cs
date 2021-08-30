using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServerDiplom.Controllers.CategoryManage.Data;
using ServerDiplom.Models;

namespace ServerDiplom.Controllers.CategoryManage
{
    [ApiController]
    public class CategoryManageController : ControllerBase
    {
        private readonly ApplicationContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly string _path;

        public CategoryManageController(ApplicationContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _appEnvironment = appEnvironment;
            _path = _appEnvironment.ContentRootPath + "/Uploads/";
        }

        [Route("get-all-categories")]
        [HttpGet]
        public async Task<List<string>> GetAllCategories()
        {
            var categories = await _db.Categories
                .OrderBy(c => c.Id)
                .Select(c => c.Name)
                .ToListAsync();

            return categories;
        }

        [Route("get-other-categories")]
        [HttpGet]
        public async Task<List<string>> GetOtherCategories()
        {
            var categories = await _db.Categories.Where(c => c.Id > 1).Select(c => c.Name).ToListAsync();

            return categories;
        }

        [Route("get-checked-categories/{documentName}")]
        [HttpGet]
        public async Task<List<string>> CheckedCategories([FromRoute] string documentName)
        {
            var checkedCategories = await _db.DocumentCategory
                .Where(dc => dc.Document.Name == documentName)
                .Select(dc => dc.Category.Name)
                .ToListAsync();

            return checkedCategories;
        }

        [Route("add-category")]
        [HttpPost]
        public async Task AddCategory([FromBody] string nameCategory)
        {
            _db.Categories.Add(new Category { Name = nameCategory });
            await _db.SaveChangesAsync();
        }

        [Route("del-category/{categoryName}")]
        [HttpDelete]
        public async Task DelCategory([FromRoute] string categoryName)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);

            var documents = await _db.DocumentCategory
                .Where(dc => dc.Category.Name == categoryName && dc.Document.Categories.Count == 1)
                .Select(dc => dc.Document)
                .ToListAsync();

            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            _db.Documents.RemoveRange(documents);
            await _db.SaveChangesAsync();

            DirectoryInfo dirInfo = new DirectoryInfo(_path);

            foreach (var doc in documents)
            {
                foreach (var dir in dirInfo.GetFiles())
                {
                    if (doc.Name == dir.Name)
                    {
                        dir.Delete();
                    }
                }
            }
        }

        [Route("edit-category")]
        [HttpPut]
        public async Task EditCategory([FromBody] CategoryEditData categoryData)
        {
            var category = await _db.Categories.FirstOrDefaultAsync(c => c.Name == categoryData.CategoryOldName);

            category.Name = categoryData.CategoryNewName;

            await _db.SaveChangesAsync();
        }
    }
}
