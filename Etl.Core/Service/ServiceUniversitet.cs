using Etl.Core.Interface;
using Etl.Core.Model;
using Etl.DataAccess.Postgres.Repository;
using System.Linq.Expressions;

namespace Etl.Core.Service
{
    public class ServiceUniversitet : IServiceUniversitet
    {
        private readonly IUniversitetsRepository _universitetsRepository;

        public ServiceUniversitet(IUniversitetsRepository universitetsRepository)
        {
            _universitetsRepository = universitetsRepository;
        }
        public async Task<List<Universitet>> GetAll()
        {
            var universitets = await _universitetsRepository.GetAllAsync();

            var data = universitets.Select(q =>
              new Universitet(
                  q.Id,
                  q.Name,
                  q.Country,
                  q.AphaTwoCode,
                  q.StateProvince,
                  q.webPageEntities,
                  q.domainEntities)
              ).ToList();

            return data;

        }

       
        public async Task<List<Universitet>> GetAll(string country, string name)
        {
            //var exp = Expression.New(typeof( Func<Universitet,bool>));

            var universitets = await _universitetsRepository.GetAllAsync(q=>q.Country.Contains(country) && q.Name.Contains(name));

            var data = universitets.Select(q =>
              new Universitet(
                  q.Id,
                  q.Name,
                  q.Country,
                  q.AphaTwoCode,
                  q.StateProvince,
                  q.webPageEntities,
                  q.domainEntities)
              ).ToList();

            return data;

        }

        public async Task<List<Universitet>> GetAllFull(string country,string name)
        {
            //var exp = Expression.New(typeof( Func<Universitet,bool>));

            var universitets = await _universitetsRepository.GetWithDomainAsync(q=>q.Country.Contains(country) && q.Name.Contains(name));

            var data = universitets.Select(q =>
              new Universitet(
                  q.Id,
                  q.Name,
                  q.Country,
                  q.AphaTwoCode,
                  q.StateProvince,
                  q.webPageEntities,
                  q.domainEntities)
              ).ToList();

            return data;

        }


    }
}
