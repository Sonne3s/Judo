using Judo.ViewModels.Components;
using Judo.ViewModels.Interfaces;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Judo.ViewModels
{
    public class ExercisesItem : IGetId
    {
        public int Id { get; set; }
        [Display(Name = "Название", Order = 1)]
        public string Name { get; set; }
        [Display(Name = "Длительность", Order = 2)]
        public TimeSpan Duration { get; set; }
        [Display(Name = "Количество", Order = 3)]
        public int Quantity { get; set; }
    }

    public class CurriculumHomeExercisesListViewModel
    {
        [UIHint("Menu")]
        public IDictionary<string, string> Menu { get; set; }

        [Table(typeof(ExercisesItem))]
        public List<ExercisesItem> Item { get; set; }
    }
}
