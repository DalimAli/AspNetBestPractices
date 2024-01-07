using System.ComponentModel.DataAnnotations;

namespace Library.Entity.ViewModels
{
    public class AuthorStatusResult
    {
        public int AuthorId { get; set; } 
        public string AuthorName { get; set; }
        public string StatusText { get; init; }

    }
}
