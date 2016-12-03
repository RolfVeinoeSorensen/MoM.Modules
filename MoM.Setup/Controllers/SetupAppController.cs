using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoM.Module.Dtos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Setup.Controllers
{
    //[Route("setup/[controller]/[action]")]
    public class SetupAppController : Controller
    {
        IOptions<SiteSettingDto> SiteSetting;

        public SetupAppController(IOptions<SiteSettingDto> siteSetting) 
        {
            SiteSetting = siteSetting;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var theme = SiteSetting.Value.theme;
            ViewData["CssPath"] = "css/" + theme.module + "/" + theme.name + "/";
            ViewData["Title"] = "Welcome to MoM Install guide";
            return View("~/Views/MoM.Setup/App/Index.cshtml");
        }

        public IActionResult App() => PartialView("~/Views/MoM.Setup/App/App.cshtml");
    }
}
