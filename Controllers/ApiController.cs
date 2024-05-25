using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMVCTakahiro.Models;

namespace WebMVCTakahiro.Controllers
{
    public class ApiController : Controller
    {
        private readonly MyDbContext _context;
        private readonly IWebHostEnvironment _hostingEnviroment;
        public ApiController(MyDbContext context, IWebHostEnvironment hostingEnviroment)
        {
            _context = context;
            _hostingEnviroment = hostingEnviroment;
        }
        public IActionResult City()
        {
            Thread.Sleep(5000);
            return Content("哈囉", "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Index()
        {

            //var cities = _context.Addresses.Select(r => r.City).Distinct();
            //return Json(cities);

            var cities = _context.Addresses
               .GroupBy(r => r.City)
               .Select(g => new { Id = g.FirstOrDefault().Id, City = g.Key });

            return Json(cities);
        }

        public IActionResult Districts(string city)
        {
            var districts = _context.Addresses
                .Where(r => r.City == city)
                .Select(r => r.SiteId)
                .Distinct();
            return Json(districts);
        }

        public IActionResult Roads(string districts)
        {
            var roads = _context.Addresses
                .Where(r => r.SiteId == districts)
                .Select(r => r.Road);
            return Json(roads);
        }

        public IActionResult Cat(int? id)
        {
            Member? member = _context.Members.Find(id);
            if (member != null)
            {
                byte[] img = member.FileData;
                if (img != null)
                {
                    return File(img, "image/jpeg");
                }
            }
            return NotFound();
        }

        public IActionResult Register(Member member, IFormFile image)
        {
            string filePath = Path.Combine(_hostingEnviroment.WebRootPath, "images", image.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }        
            byte[] fileData = null;
            using (var memoryStream = new MemoryStream())
            {
                {
                    image.CopyTo(memoryStream);
                    fileData = memoryStream.ToArray();
                }
            }
            member.FileData = fileData;
            member.FileName = image.FileName;
            _context.Members.Add(member);
            _context.SaveChanges();

            string info = $"{image.FileName}, {image.Length}, {image.ContentType}";
            return Content(info, "text/plain", System.Text.Encoding.UTF8);
        }



        public IActionResult CheckAccount(string name, string email)
        {


            var memberWithName = _context.Members.FirstOrDefault(r => r.Name == name);
            var memberWithEmail = _context.Members.FirstOrDefault(r => r.Email == email);

            if (memberWithName != null && memberWithEmail != null)
            {
                return Content("此姓名和郵件已有人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (memberWithName != null)
            {
                return Content("此姓名已有人使用", "text/html", System.Text.Encoding.UTF8);
            }
            else if (memberWithEmail != null)
            {
                return Content("此郵件已使用", "text/html", System.Text.Encoding.UTF8);
            }
            else
            {
                return Content("此姓名和郵件無人使用", "text/html", System.Text.Encoding.UTF8);
            }
        }


        [HttpPost]
        public IActionResult CheckAccount([FromBody] UserViewModel user)
        {
            if (user.Name == "Jack")
            {
                return Content("此姓名已有人使用", "text/html", System.Text.Encoding.UTF8);
            }

            if (user.Email == "Jack@Jack.com")
            {
                return Content("此郵件已使用", "text/html", System.Text.Encoding.UTF8);
            }

            return Content($"Hello! {user.Name}, {user.Age}歲了, 電子郵件是{user.Email}", "text/html", System.Text.Encoding.UTF8);

        }

        [HttpPost]
        public IActionResult Spots([FromBody] searchDTO SearchDTO)
        {
            return Json(SearchDTO);
        }

    }
}
