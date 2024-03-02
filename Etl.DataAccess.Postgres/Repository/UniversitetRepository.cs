using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Etl.DataAccess.Postgres.Repository
{
    public class UniversitetsRepository(DefaultDbContext defaultDbContext) : IUniversitetsRepository
    {
        private readonly DefaultDbContext _defaultDbContext = defaultDbContext;

        public async Task<List<UniversitetEntity>> GetAllAsync()
        {
            return await _defaultDbContext.Universities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<UniversitetEntity>> GetWithDomainAsync()
        {
            return await _defaultDbContext.Universities
                .AsNoTracking()
                .Include(q => q.domainEntities)
                .ToListAsync();
        }

        public async Task<UniversitetEntity?> GetByIdAsync(Guid id)
        {
            return await _defaultDbContext.Universities.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task AddAsync(UniversitetEntity universitetEntity)
        {
            await _defaultDbContext.AddAsync(universitetEntity);
            await _defaultDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(UniversitetEntity UpdateEntity)
        {
            await _defaultDbContext.Universities
                .Where(q => q.Id == UpdateEntity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(q => q.StateProvince, UpdateEntity.StateProvince)
                .SetProperty(q => q.webPageEntities, UpdateEntity.webPageEntities)
                .SetProperty(q => q.domainEntities, UpdateEntity.domainEntities)
                .SetProperty(q => q.AphaTwoCode, UpdateEntity.AphaTwoCode));
        }

        public async Task DeleteAsync(UniversitetEntity UpdateEntity)
        {
            await _defaultDbContext.Universities
                .Where(q => q.Id == UpdateEntity.Id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<UniversitetEntity>> GetAllAsync(Expression<Func<UniversitetEntity, bool>> predicat)
        {            
            return await  defaultDbContext.Universities
                .AsNoTracking()
                .Where(predicat).ToListAsync() ;
        }
    }
}
