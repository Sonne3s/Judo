using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Judo.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult GroupsList()
        {
            return View();
        }

        public IActionResult Disciplines()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}