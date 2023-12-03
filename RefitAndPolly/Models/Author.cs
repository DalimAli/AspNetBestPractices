using System.ComponentModel.DataAnnotations;

namespace RefitAndPolly.Models
{
    public class Author: Audit
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } 
    }
}
