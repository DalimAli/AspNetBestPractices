using LibraryApi.Context;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AuthorController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet("gets")]
        public async Task<IActionResult> Index()
        {
            var result = await context.Authors.ToListAsync();
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            return Ok(author);
        }
    }
}
