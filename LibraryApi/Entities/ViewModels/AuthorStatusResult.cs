using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Entities.ViewModels
{
    public class AuthorStatusResult
    {
        public int AuthorId { get; set; } 
        public string AuthorName { get; set; }
        public string StatusText { get; init; }

    }
}
