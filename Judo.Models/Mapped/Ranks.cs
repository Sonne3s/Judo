using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Ranks
    {
        public Ranks()
        {
            Students = new HashSet<Students>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Students> Students { get; set; }
    }
}
