using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Repository
{
    internal interface IRepositoryBase
    {
        Task<T> GetAllAsync<T>();
        Task<T> UpdateAsync<T>(T entity);
        Task<T> DeleteAsync<T>(T id);
        Task<T> AddAsync<T>(T entity);
        Task<T> GetById<T>(T id);
    }
}
