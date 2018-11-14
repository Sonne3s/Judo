using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public List<Group> Groups { get; set; }
        public IDictionary<DateTime, TimeSpan> Times { get; set; }
        public string EventType { get; set; }
    }
}
