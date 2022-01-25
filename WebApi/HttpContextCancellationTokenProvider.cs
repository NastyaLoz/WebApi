using System.Threading;
using Microsoft.AspNetCore.Http;

namespace WebApi
{
    public class HttpContextCancellationTokenProvider: ICalcellationTokenProvider
    {
        public HttpContextCancellationTokenProvider(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null && httpContextAccessor.HttpContext != null)
                CancellationToken = httpContextAccessor.HttpContext.RequestAborted;

            if (CancellationToken == null)
                CancellationToken = CancellationToken.None;
        }

        public CancellationToken CancellationToken { get; }
    }
}