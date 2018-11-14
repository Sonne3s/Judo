using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.Models.Fake
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SportKind { get; set; }
        public int Trainer { get; set; }
        public List<Person> Students { get; set; }
    }


}
