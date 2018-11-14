using Judo.Constants.ViewTemplates;
using System;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewTemplates
{
    public class TableAttribute : UIHintAttribute
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string Classes { get; set; }

        public bool Editable { get; set; }

        public Type ElementType { get; set; }

        public TableAttribute (Type elementType) : base("Table")
        {
            ElementType = elementType;
        }
    }
}
