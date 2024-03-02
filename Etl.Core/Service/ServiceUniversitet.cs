using Etl.Core.Interface;
using Etl.Core.Model;
using Etl.DataAccess.Postgres.Repository;

namespace Etl.Core.Service
{
    public class ServiceUniversitet : IServiceUniveritet
    {
        private readonly IUniversitetsRepository _universitetsRepository;

        public ServiceUniversitet(IUniversitetsRepository universitetsRepository)
        {
            _universitetsRepository = universitetsRepository;
        }
        public async Task<List<Universitet>> GetAll()
        {
            var universitets = await _universitetsRepository.GetAllAsync();

            var data = (List<Universitet>)universitets.Select(q =>
              new Universitet(
                  q.Id,
                  q.Name,
                  q.Country,
                  q.AphaTwoCode,
                  q.StateProvince,
                  q.webPageEntities,
                  q.domainEntities)
              );

            return data;

        }


    }
}
