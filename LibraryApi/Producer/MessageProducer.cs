using MassTransit;

namespace LibraryApi.Producer
{
    public class MessageProducer: IMessageProducer
    {

        private readonly IPublishEndpoint _publishEndpoint;
        public MessageProducer(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }


        public async Task SendMessage<T>(T message)
        {
           await _publishEndpoint.Publish(message);
        }

    }
}
