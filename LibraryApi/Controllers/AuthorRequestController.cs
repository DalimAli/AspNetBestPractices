using LibraryApi.Entities.ViewModels;
using LibraryApi.Models;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorRequestController : ControllerBase
    {
        readonly IRequestClient<CheckAuthorStatus> _client;

        public AuthorRequestController(IRequestClient<CheckAuthorStatus> client)
        {
            _client = client; 
        }

        [HttpGet("CheckAuthor/{authorId}")]
        public async Task<IActionResult> Get(int authorId, CancellationToken cancellationToken)
        {
            CheckAuthorStatus checkAuthorStatus =  new CheckAuthorStatus { AuthorId = authorId };
            var response = await _client.GetResponse<AuthorStatusResult>(checkAuthorStatus, cancellationToken);

            Console.WriteLine($"Got a response from author status consumer and the author name is { response.Message.AuthorName}");
            return Ok(response.Message); 
        }
    }
}
