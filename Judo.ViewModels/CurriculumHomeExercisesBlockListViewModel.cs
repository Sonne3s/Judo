using Judo.ViewModels.Interfaces;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Judo.ViewModels
{
    public class ExerciseBlockCollapseHead
    {
        [Display(Name = "Название", Order = 1)]
        public string Name { get; set; }
        [Display(Name = "Длительность", Order = 1)]
        public TimeSpan Duration { get; set; }
    }

    public class ExercisesBlockItem
    {
        [UIHint("CollapsedHead")]
        public ExerciseBlockCollapseHead Head { get; set; }
        [UIHint("CollapsedBody")]
        public ExercisesBlockItemBody Body { get; set; }
    }

    public class ExercisesBlockItemBody
    {
        [Table(typeof(ExercisesItem), Editable = true)]
        public List<ExercisesItem> Items { get; set; }
    }

    public class CurriculumHomeExercisesBlockListViewModel
    {
        [UIHint("Menu")]
        public IDictionary<string, string> Menu { get; set; }

        [UIHint("CollapsedCollection")]
        public List<ExercisesBlockItem> Item { get; set; }
    }
}