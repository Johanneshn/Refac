using System.Data;

namespace WebApplication3.Infrastructure;

public class DeviceCertReader : ICertReader
{
    public Task<CertReaderResult> BatchReadNext(int cursorPosition)
    {
        var nextCursor = cursorPosition + 2;
        var data = Helpers.Devices(cursorPosition);

        return Task.FromResult(new CertReaderResult(data, nextCursor));
    }
}

public record CertReaderResult(DataTable Data, int NewCursorPosition);