using Judo.Models.Fake;
using Judo.ViewTemplates;
using System;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewModels
{
    public class StudentsPeopleAddPersonFormViewModel
    {
        [UIHint("Ide")]
        public int Id { get; set; }

        [TextBox]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [TextBox]
        [Display(Name = "Фамилия")]
        public string MiddleName { get; set; }

        [TextBox]
        [Display(Name = "Отчество")]
        public string LastName { get; set; }

        [Date]
        [Display(Name = "Дата рождения")]
        public DateTime BirthDay { get; set; }

        [DropDown("GetSex")]
        [Display(Name = "Пол")]
        public bool Sex { get; set; }

        [DropDown("GetRoles")]
        [Display(Name = "Тип")]
        public int Role { get; set; }

        public static explicit operator Person(StudentsPeopleAddPersonFormViewModel person)
        {
            return new Person()
            {
                BirthDay = person.BirthDay,
                FirstName = person.FirstName,
                Id = person.Id,
                LastName = person.LastName,
                MiddleName = person.MiddleName,
                Role = person.Role,
                Sex = person.Sex,
            };
        }

        public Person ToPerson()
        {
            return (Person)this;
        }
    }

    public class StudentsPeopleAddPersonViewModel
    {
        [Form(Action = "AddPerson", Area = "Students", Controller = "People")]
        public StudentsPeopleAddPersonFormViewModel Form { get; set; }
    }
}