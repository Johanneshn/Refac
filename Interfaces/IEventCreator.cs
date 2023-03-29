using System.Data;

namespace WebApplication3.Interfaces
{
    public interface IEventCreator
    {
        IEnumerable<IMessage> CreateEvents(DataTable data, ICacheService cache);
    }
}