using LibraryApi.Context;
using LibraryApi.Models;
using LibraryApi.Producer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [ApiController]
    [Route("/author")]
    public class AuthorController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMessageProducer _messageProducer;
        public AuthorController(ApplicationDbContext context, IMessageProducer messageProducer)
        {
            this.context = context;
            _messageProducer = messageProducer;
        }

        [HttpGet("gets")]
        [EnableRateLimiting("fixed")]
        public async Task<IActionResult> Index()
        {
            var result = await context.Authors.ToListAsync();
            return Ok(result);
        }

        [HttpGet("get/{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("add")]
        //[EnableRateLimiting("fixed")]
        public async Task<IActionResult> Add([FromBody] Author author)
        {
            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
            Console.WriteLine($"Sending Message to consumer");
            await _messageProducer.SendMessage(author);
            return Ok(author);
        }
    }
}
