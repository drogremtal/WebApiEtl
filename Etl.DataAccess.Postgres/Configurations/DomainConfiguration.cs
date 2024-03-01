using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Configurations
{
    public class DomainConfiguration : IEntityTypeConfiguration<DomainEntity>
    {
        public void Configure(EntityTypeBuilder<DomainEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Universitet)
                .WithMany(e => e.domainEntities)
                .HasForeignKey(e=>e.UniversitetId);

        }
    }
}
