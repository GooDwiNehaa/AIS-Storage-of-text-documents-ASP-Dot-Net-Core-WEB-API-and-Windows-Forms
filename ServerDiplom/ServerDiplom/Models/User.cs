using System.ComponentModel.DataAnnotations;

namespace ServerDiplom.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string UserLogin { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(255)]
        public string UserPassword { get; set; }
        [Required]
        public int TypeUserId { get; set; }
        public TypeUser TypeUser { get; set; }
    }
}
