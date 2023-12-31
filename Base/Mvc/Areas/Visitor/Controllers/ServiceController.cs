﻿using Microsoft.AspNetCore.Mvc;

namespace Mvc.Areas.Visitor.Controllers
{
    [Area("Visitor")]
    public class ServiceController : Controller
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

        public IActionResult Hosting()
        {
            return View();
        }

        public IActionResult Desktop()
        {
            return View();
        }

        public IActionResult Web()
        {
            return View();
        }

        public IActionResult Mobile()
        {
            return View();
        }

        public IActionResult Data()
        {
            return View();
        }
    }
}
