using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServerDiplom.Models
{
    public class TypeUser
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public List<User> Users { get; set; } = new List<User>();
    }
}
