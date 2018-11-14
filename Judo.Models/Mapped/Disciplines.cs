using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Disciplines
    {
        public Disciplines()
        {
            Groups = new HashSet<Groups>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Groups> Groups { get; set; }
    }
}
