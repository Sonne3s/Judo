using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class CharacteristicToStudent
    {
        public int StudentId { get; set; }
        public int CharacteristicId { get; set; }

        public Characteristics Characteristic { get; set; }
        public Students Student { get; set; }
    }
}
