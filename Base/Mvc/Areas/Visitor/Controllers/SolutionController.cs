using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]

    public class SolutionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Scheduler()
        {
            return View();
        }

        public IActionResult Communications()
        {
            return View();
        }

        public IActionResult Ecommerce()
        {
            return View();
        }

        public IActionResult Marketing()
        {
            return View();
        }
    }
}
