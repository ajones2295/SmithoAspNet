using Microsoft.AspNetCore.Mvc;
using Models.UtilityModels;
using System.Diagnostics;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello user!");
            // create view to enable access to each action listed below
            return View();
        }

        public IActionResult Services()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }

        public IActionResult Solutions()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }

        public IActionResult Technology()
        {
            // list(bootstrap feature class) containing produced software such as ctd, bngo, online coures, ebooks, packages, etc..
            // certain items lead to eshop others lead to build custom application
            // only 4 items then see more button, 4th item being customize/see packges 
            // get started
            return View();
        }

        public IActionResult Company()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}