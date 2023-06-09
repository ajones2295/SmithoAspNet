using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]

    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Careers()
        {
            return View();
        }

        public IActionResult Community()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Blogs()
        {
            return View();
        }

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Clients()
        {
            return View();
        }

        public IActionResult Affiliates()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
