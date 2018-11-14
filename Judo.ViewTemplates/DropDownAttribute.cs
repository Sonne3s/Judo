using System.ComponentModel.DataAnnotations;

namespace Judo.ViewTemplates
{
    public sealed class DropDownAttribute : UIHintAttribute
    {
        public string Classes { get; set; }

        public string Method { get; set; }

        public object[] Parameters { get; set; }

        public int AddItem { get; set; }

        public string EditItemAction { get; set; }

        public bool NeedAddRequestTypeIdToParameters { get; set; }

        /// <summary>
        /// Will update linked control when this control is changed
        /// </summary>
        public string LinkedControlId { get; set; }

        /// <summary>
        /// Will submit a form that contains linked contol when this control is changed
        /// </summary>
        public bool LinkedControlSubmit { get; set; }

        public DropDownAttribute(string method) : base("DropDown")
        {
            this.Method = method;
        }
    }
}