using System;
using System.Collections.Generic;

namespace Judo.Models.Mapped
{
    public partial class StudentsToGroup
    {
        public int StudentId { get; set; }
        public int GroupId { get; set; }

        public Groups Group { get; set; }
        public Students Student { get; set; }
    }
}
