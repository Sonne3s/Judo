using Microsoft.AspNetCore.Mvc;
using Judo.Repository.Abstract;
using Judo.ViewModels;
using Judo.Models;

namespace Judo.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class DetailsController : Controller
    {
        IStudentsRepository repository;

        public DetailsController(IStudentsRepository _repository)
        {
            repository = _repository;
        }

        public StudentsDetailsViewModel GetViewModel(int? studentId)
        {
            var student = repository.GetById(studentId);
            var a =new StudentsDetailsViewModel()
            {
                First = student.First,
                Middle = student.Middle,
                Last = student.Last,
                BirthDate = student.BirthDate,
                Sex = student.Sex,
                Rank = new Rank() { Id = student.RankId == 0?1: student.RankId, Name = student.RankName?? "Без разряда" }
            };
            return a;
        }

        [HttpGet]
        public IActionResult Index(int studentId) =>  View(GetViewModel(studentId));

        [HttpGet]
        public IActionResult Edit(int? studentId = null) => View(GetViewModel(studentId));

        [HttpPost]
        public IActionResult Edit(StudentsDetailsViewModel student)
        {
            repository.Create(new Models.Student()
            {
                First = student.First,
                Middle = student.Middle,
                Last = student.Last,
                BirthDate = student.BirthDate,
                Sex = student.Sex,
                RankId = student.Rank.Id,
            });
            return RedirectToAction("Index", "Students");
        }
    }
}