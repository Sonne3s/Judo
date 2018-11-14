using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Characteristics
    {
        public Characteristics()
        {
            CharacteristicToStudent = new HashSet<CharacteristicToStudent>();
        }

        public int Id { get; set; }
        public string Value { get; set; }
        public int? UnitId { get; set; }
        public int TypeId { get; set; }

        public CharacteristicType Type { get; set; }
        public Units Unit { get; set; }
        public ICollection<CharacteristicToStudent> CharacteristicToStudent { get; set; }
    }
}
