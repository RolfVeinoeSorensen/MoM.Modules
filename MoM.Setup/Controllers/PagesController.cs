using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Setup.Controllers
{
    [Route("setup/[controller]/[action]")]
    public class PagesController : Controller
    {
        
        public IActionResult Welcome() => PartialView("~/Views/MoM.Setup/Pages/Welcome.cshtml");
        public IActionResult Database() => PartialView("~/Views/MoM.Setup/Pages/Database.cshtml");
    }
}
