using System.Reflection;
using Microsoft.EntityFrameworkCore;
using WebApi.Domain;
using WebApi.Extensions;

namespace WebApi
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
        
        public DbSet<TSessions> TSessions { get; set; }
        public DbSet<TChargePole> TChargePoles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyEfConfigurationsFromAssembly(Assembly.GetExecutingAssembly());            
        }
        
    }
}