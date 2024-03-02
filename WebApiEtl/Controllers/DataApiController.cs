using Etl.Core.Interface;
using Etl.Core.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiEtl.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataApiController : ControllerBase
    {
        private readonly IServiceUniveritet _serviceUniveritet;

        public DataApiController(IServiceUniveritet serviceUniveritet)
        {
            _serviceUniveritet = serviceUniveritet;
        }


        // GET: api/<DataApiController>
        [HttpGet]
        public  Task<IEnumerable<Universitet>> GetAll()
        {
            _serviceUniveritet

            return new string[] { "value1", "value2" };
        }

        // GET api/<DataApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DataApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DataApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DataApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
