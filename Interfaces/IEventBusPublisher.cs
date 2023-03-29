namespace WebApplication3.Interfaces
{
    public interface IEventBusPublisher
    {
        public void Publish<T>(T message) where T : IMessage;
    }
}