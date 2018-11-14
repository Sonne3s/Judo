using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Judo.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public override ViewResult View(object model)
        {
            this.ViewData["Controller"] = this;
            return base.View(model);
        }
    }
}