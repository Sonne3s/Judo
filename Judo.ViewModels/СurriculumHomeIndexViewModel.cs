using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.ViewModels
{
    public class СurriculumHomeIndexViewModel
    {
        [Calendar]
        public IDictionary<DateTime, int> Calendar { get; set; }
    }
}
