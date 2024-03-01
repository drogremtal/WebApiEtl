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
    public class WebPageConfiguration : IEntityTypeConfiguration<WebPageEntity>
    {
        public void Configure(EntityTypeBuilder<WebPageEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.Universitet)
                .WithMany(x=>x.webPageEntities)
                .HasForeignKey(x=>x.UniversitetId);
        }
    }
}
