using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Units
    {
        public Units()
        {
            Characteristics = new HashSet<Characteristics>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
