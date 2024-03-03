using Etl.Core.Interface;
using Etl.Core.Model;
using Etl.UploadData.UploadService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEtl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataApiController : ControllerBase
    {
        private readonly IServiceUniversitet _serviceUniversitet;
        private readonly IUploadService _uploadService;

        public DataApiController(IServiceUniversitet serviceUniveritet, IUploadService uploadService)
        {
            _serviceUniversitet = serviceUniveritet;
            _uploadService = uploadService;

        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Universitet>> GetAll(string? country = null, string? name = null)
        {
            return await _serviceUniversitet.GetAll(country, name);
        }

        [HttpGet("{country}",  Name = "GetAllFull")]
        public async Task<IEnumerable<Universitet>> GetAllFull(string country)
        {
            return await _serviceUniversitet.GetAllFull(country);
        }

        [HttpGet(Name = "StartUpload")]
        public async Task<IAsyncEnumerable<object>> StartUpload(/*string url, string country*/)
        {

            //Uri uri = new(Uri.UnescapeDataString(url));
            //Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("country", country);

            Uri uri = new Uri("http://universities.hipolabs.com/search");
            Dictionary<string, string> parameters = new Dictionary<string, string>() { { "country", "Russian Federation" } };

            var data = _uploadService.UploadData(uri, parameters);

            

            return data;

        }


    }

}
