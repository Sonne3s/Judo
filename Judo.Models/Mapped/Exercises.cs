using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class Exercises
    {
        public Exercises()
        {
            GroupsToExercise = new HashSet<GroupsToExercise>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Start { get; set; }
        public TimeSpan Duration { get; set; }

        public ICollection<GroupsToExercise> GroupsToExercise { get; set; }
    }
}
