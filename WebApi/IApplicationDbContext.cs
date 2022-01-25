using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApi.Domain;

namespace WebApi
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<TSessions> TSessions { get; set; }
        DbSet<TChargePole> TChargePoles { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
    }
}