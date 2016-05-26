using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers
{
    [Route("cms/[controller]/[action]")]
    public class WidgetsController : Controller
    {
        public IActionResult AdminNavigation() => PartialView("~/Views/MoM.CMS/Widgets/AdminNavigation.cshtml");

        public IActionResult EditorHtml() => PartialView("~/Views/MoM.CMS/Widgets/EditorHtml.cshtml");
    }
}
