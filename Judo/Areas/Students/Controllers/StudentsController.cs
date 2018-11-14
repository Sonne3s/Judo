using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Judo.ViewModels;
using Judo.Models;
using Judo.Repository.Abstract;

namespace Judo.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class StudentsController : Controller
    {
        IStudentsRepository repository;

        public StudentsController(IStudentsRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index()
        {
            var viewModel = new StudentsStudentsIndexViewModel();
            var a = repository.GetAllForTable();
            viewModel.Students = repository.GetAllForTable().Select(s => new StudentForTable()
            {
                First = s.First,
                Middle = s.Middle,
                Last = s.Last,
                Id = s.StudentId,
            }).ToList();

            return View(viewModel);
        }
    }
}