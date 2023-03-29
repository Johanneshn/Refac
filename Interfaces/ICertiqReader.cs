using System.Data;
using WebApplication3.Infrastructure;

namespace WebApplication3
{
    public interface ICertReader
    {
        Task<CertReaderResult> BatchReadNext(int cursorPosition);
    }
}