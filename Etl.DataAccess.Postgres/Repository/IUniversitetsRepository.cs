using Etl.DataAccess.Postgres.Model;
using System.Linq.Expressions;

namespace Etl.DataAccess.Postgres.Repository
{
    public interface IUniversitetsRepository
    {
        Task AddAsync(UniversitetEntity universitetEntity);
        Task DeleteAsync(UniversitetEntity UpdateEntity);
        Task UpdateAsync(UniversitetEntity UpdateEntity);
        Task<List<UniversitetEntity>> GetAllAsync();
        Task<List<UniversitetEntity>> GetAllAsync(Expression<Func<UniversitetEntity, bool>> predicat);
        Task<UniversitetEntity?> GetByIdAsync(Guid id);
        Task<List<UniversitetEntity>> GetWithDomainAsync(Expression<Func<UniversitetEntity, bool>> predicat);

    }
}