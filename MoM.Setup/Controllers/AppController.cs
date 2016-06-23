using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoM.Module.Dtos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Setup.Controllers
{
    [Route("setup/[controller]/[action]")]
    public class AppController : Controller
    {
        IOptions<SiteSettingDto> SiteSetting;

        public AppController(IOptions<SiteSettingDto> siteSetting)
        {
            SiteSetting = siteSetting;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var theme = SiteSetting.Value.Theme;
            ViewData["CssPath"] = "css/" + theme.Module + "/" + theme.Name + "/";
            return View("~/Views/MoM.Setup/App/Index.cshtml");
        }

        public IActionResult Outlet() => View("~/Views/MoM.Setup/App/Outlet.cshtml");
    }
}
