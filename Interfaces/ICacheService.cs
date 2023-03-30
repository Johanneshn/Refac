namespace WebApplication3
{
    public interface ICacheService<T>
    {
        bool IsSynced();

        Task Sync();

        bool TryGet(string key, out object? value);

        void Add(string key, object value);
    }
}