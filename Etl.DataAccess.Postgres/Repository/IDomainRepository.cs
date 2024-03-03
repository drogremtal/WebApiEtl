using Etl.DataAccess.Postgres.Model;

namespace Etl.DataAccess.Postgres.Repository
{
    public interface IDomainRepository
    {
        Task AddSingle(Guid universitetId, DomainEntity domainEntity);
        Task AddRangeAsync(Guid universitetId, List<DomainEntity> domainsEntity);
        Task Delete(DomainEntity domain);
        Task<List<DomainEntity>> GetAll();
        Task Update(DomainEntity domainEntity);
    }
}