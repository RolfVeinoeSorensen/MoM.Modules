using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MoM.Module.Dtos;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers
{
    [AllowAnonymous]
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
            var theme = SiteSetting.Value.theme;
            ViewData["CssPath"] = "css/" + theme.module + "/" + theme.name + "/";
            ViewData["Title"] = "Home";
            return View("~/Views/MoM.CMS/App/Index.cshtml");
        }

        public IActionResult Outlet() => PartialView("~/Views/MoM.CMS/App/Outlet.cshtml");
    }
}
