using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Judo.Constants.Base;
using Judo.Language.Base;
using Judo.Constants.ViewTemplates;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Judo.ViewModels;
using Judo.WebUI.Controllers;
using Judo.Repository.Concrete.Fake;
using Judo.ViewTemplates;

namespace Judo.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class PeopleController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPerson()
        {
            var viewModel = new StudentsPeopleAddPersonViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddPerson(StudentsPeopleAddPersonFormViewModel form)
        {
            People.AddPerson(form.ToPerson());
            return RedirectToAction("AddPerson");
        }

        public IActionResult AddGroup()
        {
            var viewModel = new StudentsPeopleAddGroupViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGroup(StudentsPeopleAddGroupFormViewModel form)
        {
            People.AddGroup(form.ToGroup());
            return RedirectToAction("AddGroup");
        }

        public IList<SelectListItem> GetStudents() => People.GetPeopleToString().ToSelectListItem().ToList();

        public IList<SelectListItem> GetTrainers() => People.GetPeopleToString().ToSelectListItem().ToList();

        public IList<SelectListItem> GetSportKinds() => Curriculum.GetSportKinds().Select(k => new SelectListItem() { Value = k.Id.ToString(), Text = k.Name }).ToList();

        public IList<SelectListItem> GetSex()
        {
            return new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = Language.Base.Person.Male,
                    Value = Constants.Base.Person.Male.ToString()
                },
                new SelectListItem()
                {
                    Text = Language.Base.Person.Female,
                    Value = Constants.Base.Person.Female.ToString()
                }
            };
        }

        public IList<SelectListItem> GetRoles()
        {
            return new List<SelectListItem>()
            {
            };
        }
    }
}