using Etl.DataAccess.Postgres.Configurations;
using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Etl.DataAccess.Postgres
{
    public class DefaultDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
    {
        public DbSet<UniversitetEntity> Universities { get; set; }
        public DbSet<DomainEntity> Domains { get; set; }
        public DbSet<WebPageEntity> Pages { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UniversitetConfiguration());
            modelBuilder.ApplyConfiguration(new DomainConfiguration());
            modelBuilder.ApplyConfiguration(new WebPageConfiguration());
        }


    }
}
