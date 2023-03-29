using WebApplication3.Interfaces;

namespace WebApplication3.Infrastructure
{
    public class NatsPublisher : IEventBusPublisher
    {
        public void Publish<T>(T message) where T : IMessage
        {
            return;
        }
    }
}