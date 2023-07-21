using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using Models.UtilityModels;
using Models.ViewModels;
using System.Diagnostics;
using System.Net;
using Models.DataModels;
//using System.Net.Mail;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;

        public HomeController(ILogger<HomeController> logger, IEmailSender emailSender)
        {
            _logger = logger;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Hello user!");
            // create view to enable access to each action listed below
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult HomeContact(HomeContactVM homeContactVM)
        {
            string formType = "Home Contact Form";

            if (ModelState.IsValid)
            {
                _emailSender.SendEmailAsync(SD.FORM_EMAIL_SENDER, formType, HomeMessageBuilder(homeContactVM));
            }
            return RedirectToAction(nameof(Index));
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

        public IActionResult Hosting()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }

        public IActionResult Consulting()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }

        public IActionResult Analytics()
        {
            // drop down list containing serives provided such as site maintenence, data analytics, etc..
            // only 3 items then see more button
            return View();
        }

        public IActionResult Development()
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
        
        private string HomeMessageBuilder(HomeContactVM homeContactInfo)
        {
            string message = "New inquiry from " + homeContactInfo.FirstName + " " + homeContactInfo.LastName + "." + "<br />" + "<br />" +
                             "Email Address: " + homeContactInfo.EmailAddress + "<br />" +
                             "Phone Number: " + homeContactInfo.PhoneNumber + "<br />" +
                             "Comapany Name: " + homeContactInfo.CompanyName + "<br />" +
                             "Description: " + homeContactInfo.Description + "<br />";
            return message;
        }
    }
}