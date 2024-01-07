using Library.Entity.ViewModels;
using LibraryApi.Consumers;
using MassTransit;
using RabbitMQ.Client;

namespace RefitAndPolly.Consumers
{
    public static class RegisterRabbitMqConsumer
    {
        public static void RegisterCustomConsumer(this IServiceCollection services)
        {

            services.AddMassTransit(configure =>
            {

                configure.AddConsumer<AuthorConsumer>();
                configure.AddConsumer<AuthorStatusConsumer>()
                         .Endpoint(e => e.Name = "author-status");

                configure.AddRequestClient<CheckAuthorStatus>(new Uri("exchange:author-status"));

                configure.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", _ =>
                    {
                        _.Username("guest");
                        _.Password("guest");
                    });
                    config.PrefetchCount = 20;
                    config.ConcurrentMessageLimit = 10;

                    config.ReceiveEndpoint("author-creation-event",
                        endPoint =>
                        {
                            endPoint.ExchangeType = ExchangeType.Fanout;
                            endPoint.ConfigureConsumer<AuthorConsumer>(context);
                        });

                    config.ConfigureEndpoints(context);
                });

            });
        }
    }
}
