using System.Data;
using WebApplication3.Models;
using WebApplication3.Proto;

namespace WebApplication3.Infrastructure;

public class PositionReader : ICertReader<Position>
{
    public Task<CertReaderResult> BatchReadNext(int cursorPosition)
    {
        var nextCursor = cursorPosition + 2;
        var data = Helpers.Devices(cursorPosition);

        return Task.FromResult(new CertReaderResult(data, nextCursor));
    }
}