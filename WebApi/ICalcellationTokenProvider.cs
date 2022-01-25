using System.Threading;

namespace WebApi
{
    public interface ICalcellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}