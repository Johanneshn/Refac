using WebApplication3.Interfaces;

namespace WebApplication3.Infrastructure
{
    public class NatsCursorService : ICursorService
    {
        private Dictionary<string, int> kv = new();

        public int GetCursor(string key)
        {
            if (kv.TryGetValue(key, out var cursor))
            {
                return cursor;
            }

            return 0;
        }

        public void SaveCursor(string key, int value)
        {
            kv[key] = value;
        }
    }
}