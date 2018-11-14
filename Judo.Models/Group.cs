using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Models
{
    public class Group
    {
        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }
        public string DisciplinName { get; set; }
    }
}
