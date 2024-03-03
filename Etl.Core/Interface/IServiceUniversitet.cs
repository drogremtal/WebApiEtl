using Etl.Core.Model;

namespace Etl.Core.Interface
{
    public interface IServiceUniversitet
    {
        Task<List<Universitet>> GetAll();
        Task<List<Universitet>> GetAll(string? country, string? name);
        Task<List<Universitet>> GetAllFull(string? country);

    }
}