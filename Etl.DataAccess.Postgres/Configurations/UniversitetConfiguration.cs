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
    public class UniversitetConfiguration : IEntityTypeConfiguration<UniversitetEntity>
    {
        public void Configure(EntityTypeBuilder<UniversitetEntity> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(q => q.Name).IsRequired(true);
            builder.Property(q => q.StateProvince).IsRequired(false);
            builder.HasMany(u => u.domainEntities).WithOne(d => d.Universitet);
            builder.HasMany(q => q.webPageEntities).WithOne(w => w.Universitet);
        }
    }
}
