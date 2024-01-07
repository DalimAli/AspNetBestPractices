using Library.Entity.ViewModels;
using MassTransit;
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
            CheckAuthorStatus checkAuthorStatus = new CheckAuthorStatus { AuthorId = authorId };
            var response = await _client.GetResponse<AuthorStatusResult, AuthorNotFound>(checkAuthorStatus, cancellationToken);
            if (response.Is(out Response<AuthorStatusResult> resultA))
                Console.WriteLine($"Got a response from author status consumer and the author name is {resultA.Message.AuthorName}");
            else if (response.Is(out Response<AuthorNotFound> resultb))
                Console.WriteLine($"Author not found using given Id {authorId}");
            return Ok(response.Message);
        }
    }
}
