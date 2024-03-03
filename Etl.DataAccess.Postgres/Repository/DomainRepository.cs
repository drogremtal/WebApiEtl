using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;

namespace Etl.DataAccess.Postgres.Repository
{
    public class DomainRepository : IDomainRepository
    {
        private readonly DefaultDbContext _defaultDbContext;
        public DomainRepository(DefaultDbContext defaultDbContext)
        {
            _defaultDbContext = defaultDbContext;
        }

        public async Task<List<DomainEntity>> GetAll()
        {
            return await _defaultDbContext.Domains
                .AsNoTracking()
                .ToListAsync();
        }


        public async Task AddSingle(Guid universitetId, DomainEntity domainEntity)
        {
            var Universitet = await _defaultDbContext.Universities.FirstOrDefaultAsync(q => q.Id == universitetId) ?? throw new Exception();

            domainEntity.UniversitetId = universitetId;
            await _defaultDbContext.AddAsync(domainEntity);
            await _defaultDbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(Guid universitetId, List<DomainEntity> domainEntity)
        {
         //   var Universitet = await _defaultDbContext.Universities.FirstOrDefaultAsync(q => q.Id == universitetId) ?? throw new Exception();

            domainEntity.ForEach(q=>q.UniversitetId = universitetId);

            await _defaultDbContext.AddRangeAsync(domainEntity);
            await _defaultDbContext.SaveChangesAsync();

        }

        public async Task Update(DomainEntity domainEntity)
        {
            await _defaultDbContext.Domains
                .Where(q => q.Id == domainEntity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(q => q.UniversitetId, domainEntity.UniversitetId));
        }

        public async Task Delete(DomainEntity domain)
        {
            await _defaultDbContext.Domains
                .Where(q => q.Id == domain.Id)
                .ExecuteDeleteAsync();

            await _defaultDbContext.SaveChangesAsync();
        }

    }
}
