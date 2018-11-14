using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Judo.Repository.Abstract;

namespace Judo.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class DeleteController : Controller
    {
        IStudentsRepository repository;

        public DeleteController(IStudentsRepository _repository)
        {
            repository = _repository;
        }
        public IActionResult Index(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index", "Students");
        }
    }
}