using System.ComponentModel.DataAnnotations;

namespace RefitAndPolly.Models
{
    public class Book: Audit
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
