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
            if (ModelState.IsValid)
            {
                MyMessageSender(homeContactVM);
            }
            return RedirectToAction("Index");
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


        public void SendEmail(HomeContactVM homeContact)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(homeContact.FirstName, homeContact.EmailAddress));
            message.To.Add(new MailboxAddress("Jerell", "jerell_smith_09@outlook.com"));
            message.Subject = "Hello, World!";
            message.Body = new TextPart("plain") { Text = "This is the email body." };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, useSsl: true);
                client.Authenticate("jerell.smith.09@gmail.com", "techComm40!");

                client.Send(message);
                client.Disconnect(true);
            }
        }


        public void MyMessageSender(HomeContactVM homeContact)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(homeContact.FirstName, homeContact.EmailAddress));
            message.To.Add(new MailboxAddress("Jerell", "jerell.smith.09@gmail.com"));
            message.Subject = "How you doin?";

            message.Body = new TextPart("plain")
            {
                Text = @"Hey Alice,

                What are you up to this weekend? Monica is throwing one of her parties on
                Saturday and I was hoping you could make it.

                Will you be my +1?

                -- Joey
                "
            };
        }
    }
}