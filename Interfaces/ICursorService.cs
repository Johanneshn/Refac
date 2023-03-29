namespace WebApplication3.Interfaces
{
    public interface ICursorService
    {
        void SaveCursor(string key, int value);

        int GetCursor(string key);
    }
}