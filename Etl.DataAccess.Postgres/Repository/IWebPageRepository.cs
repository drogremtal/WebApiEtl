using Etl.DataAccess.Postgres.Model;

namespace Etl.DataAccess.Postgres.Repository
{
    public interface IWebPageRepository
    {
        Task Add(Guid universitetId, WebPageEntity webPage);
        Task<List<WebPageEntity>> GetAll();
    }
}