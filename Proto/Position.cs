using WebApplication3.Interfaces;

namespace WebApplication3.Proto
{
    public record Position(string Id, string Message) : IMessage;
}