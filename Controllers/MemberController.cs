using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using WebMVCTakahiro.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebMVCTakahiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly MyDbContext db;

        public MemberController(MyDbContext _db)
        {
            this.db = _db;
        }
        // GET: api/<MemberController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MemberController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Member? m = db.Members.Find(id);
            if (m != null)
            {
                byte[]img = m.FileData;
                if (img != null)
                    return File(img, "image/jpg");
            }
            return NotFound();
        }

        // POST api/<MemberController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MemberController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MemberController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
