using Judo.Constants.ViewTemplates;
using Judo.ViewModels.Components;
using Judo.ViewModels.Interfaces;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Judo.ViewModels
{
    public class CurriculumHomeEditTrainingSectionExerciseViewModel
    {
        [DropDown("GetTrainingExercises", AddItem = Table.AddItemInModal)]
        [Display(Name = "Название", Order = 1)]
        public int Id { get; set; }
        [Display(Name = "Длительность", Order = 2)]
        public TimeSpan Duration { get; set; }
        [Display(Name = "Количество", Order = 3)]
        public int Quantity { get; set; }
    }

    public class CurriculumHomeEditTrainingSectionFormViewModel
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [Table(typeof(CurriculumHomeEditTrainingSectionExerciseViewModel))]
        public List<CurriculumHomeEditTrainingSectionExerciseViewModel> Item { get; set; }
    }

    public class CurriculumHomeEditTrainingSectionViewModel
    {
        [Form(Action = "EditTrainingSection", Controller = "Home", Area = "Curriculum")]
        public CurriculumHomeEditTrainingSectionFormViewModel Form { get; set; }
    }
}