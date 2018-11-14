using Judo.Models;
using Judo.ViewModels.Interfaces;
using Judo.ViewTemplates;
using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.ViewModels
{
    public class CurriculumHomeDetailsViewModel
    {
        [Table(typeof(EventDetailsViewModel))]
        public List<EventDetailsViewModel> Events { get; set; }
    }

    public class EventDetailsViewModel : IGetId
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string EventTypeName { get; set; }
    }
}
