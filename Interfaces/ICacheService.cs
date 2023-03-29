namespace WebApplication3
{
    public interface ICacheService
    {
        bool IsSynced();

        Task Sync();
    }
}