using MassTransit;

namespace RefitAndPolly.Consumers
{
    public static class RegisterRabbitMqConsumer
    {
        public static void RegisterCustomConsumer(this IServiceCollection services)
        {
             
            services.AddMassTransit(configure =>
            {
                configure.AddConsumer<AuthorConsumer>();
                configure.UsingRabbitMq((context, config) =>
                {
                    config.Host("localhost", "/", _ =>
                    {
                        _.Username("guest");
                        _.Password("guest");
                    });
                    config.ReceiveEndpoint("author-creation-event",
                        configureEndpoint =>
                        {
                            configureEndpoint.ConfigureConsumer<AuthorConsumer>(context);
                        });
                });
            });
        }
    }
}
