using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Judo.Repository.Concrete;
using System.Linq;
using Judo.Repository.Abstract;

namespace Judo.Controllers
{
    public class HomeController : Controller
    {
        private IPeopleRepository repository;

        public HomeController(IPeopleRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            var viewModel = repository.GetAllPeople();

            ViewData["Message"] = "Your contact page.";

            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View(/*new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }*/);
        }
    }
}
