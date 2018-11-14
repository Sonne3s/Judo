using System;
using System.Collections.Generic;
using System.Text;

namespace Judo.ViewTemplates
{
    public class DataAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public DataAttribute(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
