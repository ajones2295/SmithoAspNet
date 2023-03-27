using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Application()
        {
            return View();
        }

        public IActionResult Design()
        {
            return View();
        }

        public IActionResult Infrastructure()
        {
            return View();
        }

        public IActionResult Consulting()
        {
            return View();
        }

        public IActionResult Analytics()
        {
            return View();
        }
    }
}
