using Judo.ViewModels.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Judo.ViewModels.Components
{
    public class TrainingSection : IGetId
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [Display(Name = "Название", Order = 1)]
        public string Name { get; set; }
        [Display(Name = "Длительность", Order = 2)]
        public TimeSpan Duration { get; set; }
    }
}
