using WebApplication3.Proto;

namespace WebApplication3.Infrastructure
{
    public class PositionCache : ICacheService<Position>
    {
        private Dictionary<string, string> cache = new();
        private readonly ICacheService<Provision> provisionCache;

        public PositionCache(ICacheService<Provision> provisionCache)
        {
            this.provisionCache = provisionCache;
        }

        private bool isSynced = false;

        public void Add(string key, object value)
        {
            cache[key] = (string)value;
        }

        public bool IsSynced()
        {
            return isSynced;
        }

        public async Task Sync()
        {
            await Task.Delay(1000);
            isSynced = true;
        }

        public bool TryGet(string key, out object? value)
        {
            if (cache.TryGetValue(key, out var savedValue))
            {
                value = savedValue;
                return true;
            }
            value = null;
            return false;
        }
    }
}