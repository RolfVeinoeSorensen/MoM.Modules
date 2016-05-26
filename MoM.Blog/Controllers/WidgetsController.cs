using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers
{
    [Route("blog/[controller]/[action]")]
    public class WidgetsController : Controller
    {
        public IActionResult TopCategories() => PartialView("~/Views/MoM.Blog/Widgets/TopCategories.cshtml");
        public IActionResult LatestsPosts() => PartialView("~/Views/MoM.Blog/Widgets/LatestsPosts.cshtml");
        public IActionResult TagCloud() => PartialView("~/Views/MoM.Blog/Widgets/TagCloud.cshtml");
        
    }
}
