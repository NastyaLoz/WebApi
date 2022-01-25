using System.Threading;

namespace WebApi
{
    public class EfRepository
    {
        protected readonly IApplicationDbContext Context;
        protected readonly CancellationToken CancellationToken;

        public EfRepository(IApplicationDbContext context, ICalcellationTokenProvider cancellationTokenProvider)
        {
            Context = context;
            CancellationToken = cancellationTokenProvider.CancellationToken;
        }
    }
}