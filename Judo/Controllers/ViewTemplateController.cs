using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Judo.WebUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Judo.WebUI.Controllers
{
    public class ViewTemplateController
    {
        public IActionResult GetEditor(object model, string templateName)
        {
            return new PartialViewResult()
            {
                ViewData = new ViewDataDictionary(model.ToViewDataDictionary()),
                ViewName = $"~/Views/Shared/EditorTemplates/{templateName}.cshtml",
            };
        }

        public IActionResult GetDisplay(object model, string templateName)
        {
            return new PartialViewResult()
            {
                ViewData = new ViewDataDictionary(model.ToViewDataDictionary()),
                ViewName = $"~/Views/Shared/DisplayTemplates/{templateName}.cshtml",
            };
        }
    }
}
