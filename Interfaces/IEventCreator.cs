using System.Data;

namespace WebApplication3.Interfaces
{
    public interface IEventCreator<T>
    {
        IEnumerable<IMessage> CreateEvents(DataTable data, ICacheService<T> cache);
    }
}