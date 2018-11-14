using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class CharacteristicType
    {
        public CharacteristicType()
        {
            Characteristics = new HashSet<Characteristics>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public CharacteristicType IdNavigation { get; set; }
        public Users User { get; set; }
        public CharacteristicType InverseIdNavigation { get; set; }
        public ICollection<Characteristics> Characteristics { get; set; }
    }
}
