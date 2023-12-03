using Refit;
using RefitAndPolly.Models;

namespace RefitAndPolly.Interface 
{
    public interface IAuthorService
    {
        [Get("/author/gets")]
        public Task<List<Author>> Gets(); 
    }
}
