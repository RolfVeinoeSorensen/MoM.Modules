using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers
{
    [Route("cms/[controller]/[action]")]
    public class PagesController : Controller
    {
        public IActionResult Home() => PartialView("~/Views/MoM.CMS/Pages/Home.cshtml");

        public IActionResult Services() => PartialView("~/Views/MoM.CMS/Pages/Services.cshtml");

        public IActionResult Admin() => PartialView("~/Views/MoM.CMS/Pages/Admin.cshtml");

        public IActionResult AdminContent() => PartialView("~/Views/MoM.CMS/Pages/AdminContent.cshtml");

        public IActionResult AdminSecurity() => PartialView("~/Views/MoM.CMS/Pages/AdminSecurity.cshtml");

        public IActionResult AdminSettings() => PartialView("~/Views/MoM.CMS/Pages/AdminSettings.cshtml");

        public IActionResult AdminReports() => PartialView("~/Views/MoM.CMS/Pages/AdminReports.cshtml");

        public IActionResult AdminModules() => PartialView("~/Views/MoM.CMS/Pages/AdminModules.cshtml");
    }
}
