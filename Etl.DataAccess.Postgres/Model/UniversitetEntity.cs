using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Model
{
    public class UniversitetEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string AphaTwoCode { get; set; } = string.Empty;
        public string StateProvince { get; set; } = string.Empty;     
        public List<WebPageEntity> webPageEntities { get; set; } = [];
        public List<DomainEntity> domainEntities { get; set; } = [];

    }
}
