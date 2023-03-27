using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class FeaturedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bngo()
        {
            return View();
        }

        public IActionResult RegalRoots()
        {
            return View();
        }

        public IActionResult ApoclypsePrepared()
        {
            return View();
        }
    }
}
