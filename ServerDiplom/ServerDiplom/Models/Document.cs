using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerDiplom.Models
{
    public class Document
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(300)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Path { get; set; }

        public List<Category> Categories { get; set; } = new List<Category>();

        public List<DocumentCategory> DocumentCategories { get; set; } = new List<DocumentCategory>();
    }
}
