using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Repository
{
    public class UniversitetsRepository(DefaultDbContext defaultDbContext)
    {
        private readonly DefaultDbContext _defaultDbContext = defaultDbContext;

        public async Task<List<UniversitetEntity>> Get()
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
                query  =query.Where(q => q.Country.Contains(Country));
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



    }
}
