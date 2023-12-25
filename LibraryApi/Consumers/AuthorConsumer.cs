using LibraryApi.Models;
using MassTransit;
using System.Text.Json;

namespace RefitAndPolly.Consumers
{
    public class AuthorConsumer : IConsumer<Author>
    {
        public Task Consume(ConsumeContext<Author> context)
        {
            var author = JsonSerializer.Serialize(context.Message);
            Console.WriteLine($"Author created message: {author}");

            // JsonSerializer.Deserialize<Author>(context.Message);

            return Task.CompletedTask;
        }
    }
}
