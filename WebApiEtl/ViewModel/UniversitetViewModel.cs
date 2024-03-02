using Etl.DataAccess.Postgres.Model;

namespace WebApiEtl.ViewModel
{
    public class UniversitetViewModel
    {
        public UniversitetViewModel (Guid id, string name, string Country, string AphaTwoCode, string StateProvince
            , List<WebPageEntity> webPages, List<DomainEntity> domains)
        {
            this.Id = id;
            this.Name = name;
            this.Country = Country;
            this.AphaTwoCode = AphaTwoCode;
            this.StateProvince = StateProvince;
            this.webPageEntities = webPages;
            domainEntities = domains;
        }

        public Guid Id { get; }
        public string Name { get; } = string.Empty;
        public string Country { get; } = string.Empty;
        public string AphaTwoCode { get; } = string.Empty;
        public string StateProvince { get; } = string.Empty;
        public List<WebPageEntity> webPageEntities { get; } = [];
        public List<DomainEntity> domainEntities { get; } = [];

    }
}
