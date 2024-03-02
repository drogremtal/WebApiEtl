using Etl.Core.Model;

namespace Etl.Core.Interface
{
    public interface IServiceUniveritet
    {
        Task<List<Universitet>> GetAll();
    }
}