using System.Data;
using WebApplication3.Models;
using WebApplication3.Proto;

namespace WebApplication3.Infrastructure;

public class DeviceReader : ICertReader<Provision>
{
    public Task<CertReaderResult> BatchReadNext(int cursorPosition)
    {
        var nextCursor = cursorPosition + 1;
        var data = Helpers.Positions(cursorPosition);

        return Task.FromResult(new CertReaderResult(data, nextCursor));
    }
}

public record CertReaderResult(DataTable Data, int NewCursorPosition);