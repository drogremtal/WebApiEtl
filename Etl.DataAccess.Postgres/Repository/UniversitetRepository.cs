using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;

namespace Etl.DataAccess.Postgres.Repository
{
    public class UniversitetsRepository(DefaultDbContext defaultDbContext)
    {
        private readonly DefaultDbContext _defaultDbContext = defaultDbContext;

        public async Task<List<UniversitetEntity>> GetAll()
        {
            return await _defaultDbContext.Universities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<UniversitetEntity>> GetWithDomain()
        {
            return await _defaultDbContext.Universities
                .AsNoTracking()
                .Include(q => q.domainEntities)
                .ToListAsync();
        }

        public async Task<UniversitetEntity?> GetUniversitetById(Guid id)
        {
            return await _defaultDbContext.Universities.FirstOrDefaultAsync(q => q.Id == id);
        }


        public async Task<List<UniversitetEntity>> GetUniversitetEntityAsync(string Name, string Country)
        {
            var query = _defaultDbContext.Universities.AsNoTracking();

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(q => q.Name.Contains(Name));
            }

            if (!string.IsNullOrEmpty(Country))
            {
                query = query.Where(q => q.Country.Contains(Country));
            }

            return await query.ToListAsync();
        }

        public async Task<List<UniversitetEntity>> GetByPage(int page, int count)
        {
            var query = _defaultDbContext.Universities.AsNoTracking();

            query = query.AsNoTracking()
                .Skip((page-1)*count)
                .Take(count);

            return await query.ToListAsync();
        }


        public async Task Add(UniversitetEntity universitetEntity)
        {
            await _defaultDbContext.AddAsync(universitetEntity);
            await _defaultDbContext.SaveChangesAsync();
        }

        public async Task Update(UniversitetEntity UpdateEntity)
        {

            await _defaultDbContext.Universities
                .Where(q => q.Id == UpdateEntity.Id)
                .ExecuteUpdateAsync(s => s
                .SetProperty(q => q.StateProvince, UpdateEntity.StateProvince)
                .SetProperty(q => q.webPageEntities, UpdateEntity.webPageEntities)
                .SetProperty(q => q.domainEntities, UpdateEntity.domainEntities)
                .SetProperty(q => q.AphaTwoCode, UpdateEntity.AphaTwoCode)
                .SetProperty(q => q., UpdateEntity.AphaTwoCode));

        }

        public async Task Delete(UniversitetEntity UpdateEntity)
        {

            await _defaultDbContext.Universities
                .Where(q => q.Id == UpdateEntity.Id)
                .ExecuteDeleteAsync();

        }



    }
}
