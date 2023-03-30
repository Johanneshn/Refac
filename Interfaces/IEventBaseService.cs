using WebApplication3.Interfaces;

namespace WebApplication3
{
    public interface IEventBaseService<T>
    {
        Task Execute();
    }
}