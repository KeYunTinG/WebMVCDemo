using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVCTakahiro.Models;

namespace WebMVCTakahiro.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext db;

        public HomeController(MyDbContext _db)
        {
            this.db = _db;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult SpotImages()
        {
            return View(db.SpotImages);
        }

        public IActionResult First()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Hello()
        {
            return Content("<h2>Hello World</h2>", "text/html", System.Text.Encoding.UTF8);
        }
    }
}
