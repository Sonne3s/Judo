using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Students
    {
        public Students()
        {
            CharacteristicToStudent = new HashSet<CharacteristicToStudent>();
            StudentsToGroup = new HashSet<StudentsToGroup>();
        }

        public int Id { get; set; }
        public int PeopleId { get; set; }
        public int RankId { get; set; }

        public People People { get; set; }
        public Ranks Rank { get; set; }
        public ICollection<CharacteristicToStudent> CharacteristicToStudent { get; set; }
        public ICollection<StudentsToGroup> StudentsToGroup { get; set; }
    }
}
