using Microsoft.AspNetCore.Mvc;
using WebMVCTakahiro.Models;

namespace WebMVCTakahiro.Controllers
{
    public class HWController : Controller
    {
        private readonly MyDbContext db;

        public HWController(MyDbContext _db)
        {
            this.db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HW1()
        {
            return View();
        }

        public IActionResult HW2()
        {
            return View();
        }

        public IActionResult HW3()
        {
            return View();
        }
    }
}
