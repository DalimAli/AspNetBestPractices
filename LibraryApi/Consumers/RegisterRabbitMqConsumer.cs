using LibraryApi.Consumers;
using LibraryApi.Entities.ViewModels;
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

                    //config.ReceiveEndpoint("author-status",
                    //    endPoint =>
                    //    {
                    //        endPoint.ExchangeType = ExchangeType.Fanout;
                    //        endPoint.ConfigureConsumer<AuthorStatusConsumer>(context);
                    //    });
                    config.ConfigureEndpoints(context);
                });

            });
        }
    }
}
