using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class IndustryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
