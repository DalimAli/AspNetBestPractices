using LibraryApi.Context;
using LibraryApi.Models;
using MassTransit;
using MassTransit.Transports;
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
