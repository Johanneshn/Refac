namespace WebApplication3.Interfaces
{
    public interface IMessage
    {
        string Id { get; }
        string Message { get; }
    }

    public record DeviceProvisionedEvent(string Id, string Message, string SourceId) : IMessage;
}