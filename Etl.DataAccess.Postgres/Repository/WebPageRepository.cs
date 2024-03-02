using Etl.DataAccess.Postgres.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etl.DataAccess.Postgres.Repository
{
    public class WebPageRepository
    {
        private readonly DefaultDbContext _defaultDbContext;
        public WebPageRepository(DefaultDbContext defaultDbContext)
        {
            _defaultDbContext=defaultDbContext;
        }

        public async Task<List<WebPageEntity>> GetAll()
        {
            return await _defaultDbContext.Pages.ToListAsync();
        }

        public async Task Add(Guid universitetId, WebPageEntity webPage)
        {

            UniversitetEntity universitetEntity = await _defaultDbContext.Universities.FirstOrDefaultAsync(q => q.Id == universitetId)
                ?? throw new Exception();

            await _defaultDbContext.Pages.AddAsync(webPage);
        }




    }
}
