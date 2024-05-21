using Microsoft.AspNetCore.Mvc;
using WebMVCTakahiro.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVCTakahiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly MyDbContext db;

        public AddressController(MyDbContext _db)
        {
            this.db = _db;
        }
        // GET: api/<AddressController>
        [HttpGet]
        public ActionResult<IEnumerable<Address>> Get()
        {
            var result = db.Addresses.Select(x => x.City).Distinct();
            return Ok(result);
        }

        // GET api/<AddressController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AddressController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AddressController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
