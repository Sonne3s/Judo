using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Judo.Repository.Abstract;
using Judo.ViewModels;
using Judo.Repository.Concrete.Fake;
using Judo.ViewModels.Components;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Judo.WebUI.Areas.Сurriculum.Controllers
{
    [Area("Curriculum")]
    public class HomeController : Controller
    {
        IСurriculumRepository repository;

        public HomeController(IСurriculumRepository _repository)
        {
            repository = _repository;
        }

        public IActionResult Index(int? _month, int? _year)
        {
            СurriculumHomeIndexViewModel viewModel = new СurriculumHomeIndexViewModel();
            viewModel.Calendar = repository.GetCalendar(_month, _year);
            return View(viewModel);
        }

        public IActionResult TrainingList()
        {
            return View();
        }

        public IActionResult TrainingSectionsList()
        {
            return View();
        }

        public IActionResult GroupList()
        {
            List<TrainingSection> items = Curriculum.Trainings[0].Sections.Select(t => new TrainingSection() { Id = t.Id, Duration = t.Duration, Name = t.Name }).ToList();
            СurriculumHomeEditTrainingFormViewModel form = new СurriculumHomeEditTrainingFormViewModel() { Id = 1, TrainingSections = items.Select(i => new DropDownTrainingSection() { Id = i.Id, TrainingSection = i.Name + i.Duration.ToString() }).ToList() };
            СurriculumHomeEditTrainingViewModel viewModel = new СurriculumHomeEditTrainingViewModel() { Form = form };
            this.ViewData["Controller"] = this;
            return View(viewModel);
        }

        public IActionResult ExercisesBlockList()
        {
            List<ExercisesItem> items = new List<ExercisesItem>() { new ExercisesItem() { Duration = new TimeSpan(0, 10, 0), Name = "Разминка стоя", Quantity = 0 }, new ExercisesItem() { Duration = new TimeSpan(0, 5, 0), Name = "Разминка лежа", Quantity = 0 } };
            ExercisesBlockItem blockitem = new ExercisesBlockItem() { Head = new ExerciseBlockCollapseHead() { Duration = new TimeSpan(0, 15, 0), Name = "Разминка" }, Body = new ExercisesBlockItemBody() { Items = items } };
            List<ExercisesBlockItem> blocks = new List<ExercisesBlockItem>() { blockitem, blockitem, blockitem};
            var viewModel = new CurriculumHomeExercisesBlockListViewModel() { Menu = new Dictionary<string, string>() { { "11", "12" } }, Item = blocks };
            return View(viewModel);
        }

        public IActionResult ExercisesBlockEdit()
        {
            List<ExercisesItem> items = new List<ExercisesItem>() { new ExercisesItem() { Duration = new TimeSpan(0, 10, 0), Name = "Разминка стоя", Quantity = 0 }, new ExercisesItem() { Duration = new TimeSpan(0, 5, 0), Name = "Разминка лежа", Quantity = 0 } };
            ExercisesBlockItem blockitem = new ExercisesBlockItem() { Head = new ExerciseBlockCollapseHead() { Duration = new TimeSpan(0, 15, 0), Name = "Разминка" }, Body = new ExercisesBlockItemBody() { Items = items } };
            List<ExercisesBlockItem> blocks = new List<ExercisesBlockItem>() { blockitem, blockitem, blockitem };
            var viewModel = new CurriculumHomeExercisesBlockListViewModel() { Menu = new Dictionary<string, string>() { { "11", "12" } }, Item = blocks };
            return View(viewModel);
        }

        public IActionResult ExercisesList()
        {
            CurriculumHomeExercisesListViewModel viewModel = new CurriculumHomeExercisesListViewModel() { Menu = new Dictionary<string, string>() { { "11", "12" } }, Item = new List<ExercisesItem>() { new ExercisesItem() { Duration = new TimeSpan(0,15,0), Name = "Разминка", Quantity = 0 } } };
            return View(viewModel);
        }

        public IActionResult EditTraining()
        {
            List<TrainingSection> items = Curriculum.Trainings[0].Sections.Select(t => new TrainingSection() { Id = t.Id, Duration = t.Duration, Name = t.Name}).ToList();
            СurriculumHomeEditTrainingFormViewModel form = new СurriculumHomeEditTrainingFormViewModel() {Id = 1, TrainingSections = items.Select(i => new DropDownTrainingSection() {Id = i.Id, TrainingSection = i.Name + i.Duration.ToString()}).ToList() };
            СurriculumHomeEditTrainingViewModel viewModel = new СurriculumHomeEditTrainingViewModel() { Form = form };
            this.ViewData["Controller"] = this;
            return View(viewModel);
        }

        public IList<SelectListItem> GetTrainigSections()
        {
            var output = Curriculum
                .Sections
                .Select(s => new SelectListItem() { Value = s.Id.ToString(), Text = $"{s.Name} {s.Duration}" })
                .ToList();
            output.Add(new SelectListItem() { Value = "button", Text = "Добавить..."});
            return output;
        }

        public IList<SelectListItem> GetTrainingExercises()
        {
            var output = Curriculum
                .Exercises
                .Select(e => new SelectListItem() { Value = e.Id.ToString(), Text = e.Name })
                .ToList();
            output.Add(new SelectListItem() { Value = "button", Text = "Добавить..." });
            return output;
        }

        [HttpGet]
        public ActionResult AddExercise(string name)
        {
            var output = Curriculum.Exercises.FirstOrDefault(e => e.Name == name.Trim());
            if (output == null)
            {
                output = new FakeExercise() { Name = name, Id = Curriculum.Exercises.Max(e => e.Id) + 1 };
                Curriculum.Exercises.Add(output);
            }
            return Json(output);
        }

        //[HttpPost]
        //public IActionResult EditTraining(СurriculumHomeEditTrainingViewModel _form)
        //{
        //    FakeRepository.AddTraining(new FakeTraining() { Id = _form.Form.Id, Sections = _form.Form.Item.Select(t => new FakeTrainingSection() {Id = t.Id, Name = t.Name, Duration = t.Duration }).ToList() });
        //    return RedirectToAction("ExercisesBlockList");
        //}

        public IActionResult EditTrainingSection()
        {
            var items = Curriculum.Sections.Last().Exercises.Select(t => new CurriculumHomeEditTrainingSectionExerciseViewModel() { Id = t.Id, Duration = t.Duration}).ToList();
            var form = new CurriculumHomeEditTrainingSectionFormViewModel() { Id = Curriculum.Sections.Last().Id, Item = items };
            var viewModel = new CurriculumHomeEditTrainingSectionViewModel() { Form = form };
            this.ViewData["Controller"] = this;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditTrainingSection(CurriculumHomeEditTrainingSectionViewModel model)
        {
            var section = Curriculum.Sections.Find(s => s.Id == model.Form.Id);

            if(section == null)
            {
                Curriculum.Sections.Add(new FakeTrainingSection()
                {
                    Id = model.Form.Id,
                    Exercises = model.Form.Item
                    .Where(e => e.Id > 0)
                    .Select(e => new FakeExercise()
                    {
                        Id = e.Id,
                        Name = Curriculum.Exercises.Find(x => x.Id == e.Id).Name,
                        Duration = e.Duration,
                        Quantity = e.Quantity
                    })
                    .ToList()
                });
            }
            else
            {
                section.Exercises = model.Form.Item
                    .Where(e => e.Id > 0)
                    .Select(e => new FakeExercise()
                    {
                        Id = e.Id,
                        Name = Curriculum.Exercises.Find(x => x.Id == e.Id).Name,
                        Duration = e.Duration,
                        Quantity = e.Quantity
                    })
                    .ToList();
            }
            
            return RedirectToAction("EditTrainingSection");
        }

        public IActionResult Details(int _day, int _month, int _year)
        {
            return View();
        }

    }
}