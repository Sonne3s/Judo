using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Users
    {
        public Users()
        {
            CharacteristicType = new HashSet<CharacteristicType>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<CharacteristicType> CharacteristicType { get; set; }
    }
}
