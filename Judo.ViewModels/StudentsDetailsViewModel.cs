using Judo.Models;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewModels
{
    public class StudentsDetailsViewModel
    {
        [TextBox]
        [Display(Name = "Имя", Order = 1)]
        public string First { get; set; }

        [TextBox]
        [Display(Name = "Фамилия", Order = 2)]
        public string Last { get; set; }

        [TextBox]
        [Display(Name = "Отчество", Order = 3)]
        public string Middle { get; set; }

        [Sex]
        [Display(Name = "Пол", Order = 4)]
        public bool Sex { get; set; }

        [Date]
        [Display(Name = "Дата рождения", Order = 5)]
        public DateTime? BirthDate { get; set; }

        [Rank]
        [Display(Name = "Дан", Order = 6)]
        public Rank Rank { get; set; }

        [Button]
        [Display(Name = "Добавить ученика", Order = 7)]
        public int Add { get; set; }
    }
}
