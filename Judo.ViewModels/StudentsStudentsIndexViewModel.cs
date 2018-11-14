using System;
using System.Collections.Generic;
using Judo.ViewTemplates;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Judo.ViewHelpers;
using Judo.ViewModels.Interfaces;

namespace Judo.ViewModels
{
    public class StudentForTable : IGetId
    {
        [Display(Name = "Фамилия", Order = 1)]
        public string Last { get; set; }

        [Display(Name = "Имя", Order = 2)]
        public string First { get; set; }

        [Display(Name = "Отчество", Order = 3)]
        public string Middle { get; set; }

        [Button("Delete", "Index", "Students", Classes = ButtonColor.Danger)]
        [Display(Name = "Удалить", Order = 4)]
        public int Id { get; set; }
       /* public string Group { get; set; }*/
    }

    public class StudentsStudentsIndexViewModel
    {
        [Button("Details", "Edit", "Students", Classes = ButtonColor.Primary)]
        [Display(Name = "Добавить ученика", Order = 1)]
        public int Add { get; set; }

        [Table(typeof(StudentForTable))]
        public List<StudentForTable> Students { get; set; }

        [Exclude]
        public int Page { get; set;}
    }
}
