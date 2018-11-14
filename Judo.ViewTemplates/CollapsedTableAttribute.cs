using System;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewTemplates
{
    public class CollapsedTableAttribute : UIHintAttribute
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string Classes { get; set; }
        public Type ElementType { get; set; }

        public CollapsedTableAttribute(Type elementType) : base("CollapsedTable")
        {
            ElementType = elementType;
        }
    }
}
