using Judo.Models.Fake;
using Judo.Repository.Concrete.Fake;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Judo.ViewModels
{
    public class StudentsPeopleAddGroupStudentViewModel
    {
        [DropDown("GetStudents")]
        public int Student { get; set; }
    }

    public class StudentsPeopleAddGroupFormViewModel
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [TextBox]
        public string Name { get; set; }
        [DropDown("GetSportKinds")]
        public int SportKind { get; set; }
        [DropDown("GetTrainers")]
        public int Trainer { get; set; }
        [Table(typeof(StudentsPeopleAddGroupStudentViewModel))]
        public List<StudentsPeopleAddGroupStudentViewModel> Students { get; set; } = new List<StudentsPeopleAddGroupStudentViewModel>();

        public static explicit operator Group(StudentsPeopleAddGroupFormViewModel form)
        {
            return new Group()
            {
                Id = form.Id,
                Name = form.Name,
                SportKind = form.SportKind,
                Students = form.Students.Select(s => People.GetPerson(s.Student)).ToList(),
                Trainer = form.Trainer,
            };
        }
        public Group ToGroup()
        {
            return (Group)this;
        }
    }

    public class StudentsPeopleAddGroupViewModel
    {
        [Form(Action = "AddGroup", Area = "Students", Controller = "People")]
        public StudentsPeopleAddGroupFormViewModel Form { get; set; } = new StudentsPeopleAddGroupFormViewModel();
    }
}
