using System.Data;
using WebApplication3.Infrastructure;

namespace WebApplication3
{
    public interface ICertReader<T>
    {
        Task<CertReaderResult> BatchReadNext(int cursorPosition);
    }
}