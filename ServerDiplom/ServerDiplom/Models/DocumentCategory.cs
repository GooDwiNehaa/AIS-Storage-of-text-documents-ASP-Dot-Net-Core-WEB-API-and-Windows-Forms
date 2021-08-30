using System.ComponentModel.DataAnnotations;

namespace ServerDiplom.Models
{
    public class DocumentCategory
    {
        [Required]
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
