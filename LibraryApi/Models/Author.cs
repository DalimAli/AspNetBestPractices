using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Author: Audit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 
    }
}
