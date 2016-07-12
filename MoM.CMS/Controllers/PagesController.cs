using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoM.CMS.Models;
using MoM.Module.Interfaces;
using MoM.Module.Models;

namespace MoM.CMS.Controllers
{
    [AllowAnonymous]
    [Route("cms/[controller]/[action]")]
    public class PagesController : Controller
    {
        private IDataStorage Storage;
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly IAuthorizationService AuthorizationService;

        public PagesController(
            IDataStorage storage,
            UserManager<ApplicationUser> userManager,
            IAuthorizationService authorizationService)
        {
            Storage = storage;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }

        public IActionResult Home() => PartialView("~/Views/MoM.CMS/Pages/Home.cshtml");


        public IActionResult Services() => PartialView("~/Views/MoM.CMS/Pages/Services.cshtml");

        public IActionResult Products() => PartialView("~/Views/MoM.CMS/Pages/Products.cshtml");


        //Admin
        [Authorize(Policy = "AdminAccess")]
        public IActionResult Admin() => PartialView("~/Views/MoM.CMS/Pages/Admin.cshtml");

        public IActionResult AdminInfo() => PartialView("~/Views/MoM.CMS/Pages/AdminInfo.cshtml");

        public IActionResult AdminContent() => PartialView("~/Views/MoM.CMS/Pages/AdminContent.cshtml");
        public IActionResult AdminContentPages() => PartialView("~/Views/MoM.CMS/Pages/AdminContentPages.cshtml");
        public IActionResult AdminContentPage() => PartialView("~/Views/MoM.CMS/Pages/AdminContentPage.cshtml");

        public IActionResult AdminSecurity() => PartialView("~/Views/MoM.CMS/Pages/AdminSecurity.cshtml");
        public IActionResult AdminSecurityUsers() => PartialView("~/Views/MoM.CMS/Pages/AdminSecurityUsers.cshtml");
        public IActionResult AdminSecurityRoles() => PartialView("~/Views/MoM.CMS/Pages/AdminSecurityRoles.cshtml");
        public IActionResult AdminSecurityPermissions() => PartialView("~/Views/MoM.CMS/Pages/AdminSecurityPermissions.cshtml");

        public IActionResult AdminSettings() => PartialView("~/Views/MoM.CMS/Pages/AdminSettings.cshtml");

        public IActionResult AdminReports() => PartialView("~/Views/MoM.CMS/Pages/AdminReports.cshtml");

        public IActionResult AdminModules() => PartialView("~/Views/MoM.CMS/Pages/AdminModules.cshtml");
    }
}
