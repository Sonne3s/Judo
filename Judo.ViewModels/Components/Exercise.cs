using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Judo.ViewModels.Components
{
    public class Exercise
    {
        [UIHint("Ide")]
        public int Id { get; set; }
        [Display(Name = "Название", Order = 1)]
        public string Name { get; set; }
        [Display(Name = "Длительность", Order = 2)]
        public TimeSpan Duration { get; set; }
        [Display(Name = "Количество", Order = 3)]
        public int Quantity { get; set; }
    }
}
