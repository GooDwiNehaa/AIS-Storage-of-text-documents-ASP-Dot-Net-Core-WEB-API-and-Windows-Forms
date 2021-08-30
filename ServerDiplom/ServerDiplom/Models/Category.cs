using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerDiplom.Models
{
    public class Category
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public List<Document> Documents { get; set; } = new List<Document>();

        public List<DocumentCategory> DocumentCategories { get; set; } = new List<DocumentCategory>();
    }
}
