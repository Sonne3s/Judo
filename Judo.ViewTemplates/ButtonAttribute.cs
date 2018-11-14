using Judo.ViewHelpers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewTemplates
{
    public class ButtonAttribute : UIHintAttribute
    {
        public string Controller { get; set; }

        public string Action { get; set; }

        public string Area { get; set; }

        public string Classes { get; set; }

        public IDictionary<string, string> DataValues { get; set; }

        public ButtonAttribute() : base("Button")
        {
        }

        public ButtonAttribute(string controller, string action, string area = null) : base("Button")
        {
            Controller = controller;
            Action = action;
            Area = area;
        }
    }
}
