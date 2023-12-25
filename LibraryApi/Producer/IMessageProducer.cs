namespace LibraryApi.Producer
{
    public interface IMessageProducer
    {
        Task SendMessage<T>(T message);
    }
}
