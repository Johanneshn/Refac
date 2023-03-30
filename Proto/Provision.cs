using WebApplication3.Interfaces;

namespace WebApplication3.Proto
{
    public record Provision(string Id, string Message, string SourceId) : IMessage;
}