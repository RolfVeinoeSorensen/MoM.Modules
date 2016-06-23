using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Setup.Controllers
{
    [Route("setup/[controller]/[action]")]
    public class PagesController : Controller
    {
        
        public IActionResult SetupGuide() => PartialView("~/Views/MoM.Setup/Pages/SetupGuide.cshtml");
    }
}
