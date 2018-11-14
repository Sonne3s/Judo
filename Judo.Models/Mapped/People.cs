using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class People
    {
        public People()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Sex { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
