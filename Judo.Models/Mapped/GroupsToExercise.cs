using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class GroupsToExercise
    {
        public int GroupId { get; set; }
        public int ExerciseId { get; set; }

        public Exercises Exercise { get; set; }
        public Groups Group { get; set; }
    }
}
