using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Model
{
    public class DomainEntity
    {
        public Guid Id { get; set; }
        public string Domain { get; set; }=string.Empty;
        public Guid UniversitetId { get; set; }
        public UniversitetEntity Universitet { get; set; } = new UniversitetEntity();
    }
}
