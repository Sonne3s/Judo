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
    public class СurriculumHomeEditTrainingFormViewModel
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [Table(typeof(DropDownTrainingSection))]
        public List<DropDownTrainingSection> TrainingSections { get; set; }
    }

    public class DropDownTrainingSection
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [DropDown("GetTrainigSections", AddItem = Table.AddItemInNewPage)]
        public string TrainingSection { get; set; }
    }

    public class СurriculumHomeEditTrainingViewModel
    {
        [Form(Action = "EditTraining", Controller = "Home", Area = "Curriculum")]
        public СurriculumHomeEditTrainingFormViewModel Form { get; set; }
    }
}
