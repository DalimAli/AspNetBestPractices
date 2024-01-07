using Library.Entity.Models;
using MassTransit;
using System.Text.Json;

namespace RefitAndPolly.Consumers
{
    public class AuthorConsumer : IConsumer<Author>
    {
 
        public Task Consume(ConsumeContext<Author> context)
        {
            var author = JsonSerializer.Serialize(context.Message);

            Console.WriteLine($"*******************************************************************************");
            Console.WriteLine($"Author created info: {author}");
            Console.WriteLine($"*******************************************************************************");

            return Task.CompletedTask;
        }
    }
}
