namespace WebApplication3.Infrastructure
{
    public class DeviceCache : ICacheService
    {
        private bool isSynced = false;

        public bool IsSynced()
        {
            return isSynced;
        }

        public async Task Sync()
        {
            await Task.Delay(1000);
            isSynced = true;
        }
    }
}