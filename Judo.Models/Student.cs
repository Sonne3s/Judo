using Judo.Models.Mapped;
using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public int PeopleId { get; set; }
        public int RankId { get; set; }

        public string First { get; set; }
        public string Middle { get; set; }
        public string Last { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Sex { get; set; }

        public string RankName { get; set; }
        public List<CharacteristicToStudent> CharacteristicToStudent { get; set; }
    }
}
