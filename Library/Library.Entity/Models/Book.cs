using System.ComponentModel.DataAnnotations;

namespace Library.Entity.Models
{
    public class Book: Audit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
