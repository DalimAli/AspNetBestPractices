using Microsoft.AspNetCore.Mvc;
using RefitAndPolly.Interface;

namespace RefitAndPolly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("gets")]
        public async Task<IActionResult> Index()
        {
            var result = await _authorService.Gets();
            return Ok(result);
        }

    }
}
