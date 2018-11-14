using System;
using System.ComponentModel.DataAnnotations;

namespace Judo.ViewTemplates
{
    public class FormAttribute : UIHintAttribute
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string Classes { get; set; }

        public FormAttribute() : base("Form")
        {
        }
    }
}
