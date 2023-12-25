using LibraryApi.Context;
using LibraryApi.Entities.ViewModels;
using LibraryApi.Models;
using MassTransit;

namespace LibraryApi.Consumers
{
    public class AuthorStatusConsumer : IConsumer<CheckAuthorStatus>
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorStatusConsumer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<CheckAuthorStatus> context)
        {
            var author = await _dbContext.FindAsync<Author>(context.Message.AuthorId); 
            if (author == null)
                throw new InvalidOperationException("Author not found");

            await context.RespondAsync<AuthorStatusResult>(new AuthorStatusResult
            {
                AuthorId = author.Id,
                AuthorName = author.Name,
                StatusText = "Author found"
            });
        }
    }
}
