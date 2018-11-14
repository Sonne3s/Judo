using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Groups
    {
        public Groups()
        {
            GroupsToExercise = new HashSet<GroupsToExercise>();
            StudentsToGroup = new HashSet<StudentsToGroup>();
        }

        public int Id { get; set; }
        public int DisciplineId { get; set; }
        public string Name { get; set; }

        public Disciplines Discipline { get; set; }
        public ICollection<GroupsToExercise> GroupsToExercise { get; set; }
        public ICollection<StudentsToGroup> StudentsToGroup { get; set; }
    }
}
