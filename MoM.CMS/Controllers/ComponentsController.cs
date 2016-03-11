using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers
{
    public class ComponentsController : Controller
    {
        public IActionResult Template() => PartialView();

        public IActionResult Home() => PartialView();

        public IActionResult Services() => PartialView();

        public IActionResult Admin() => PartialView();
    }
}
