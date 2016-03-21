using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers
{
    [Route("blog/[controller]/[action]")]
    public class PagesController : Controller
    {
        // Public
        public IActionResult Blog() => PartialView("~/Views/MoM.Blog/Pages/Blog.cshtml");
        public IActionResult Post() => PartialView("~/Views/MoM.Blog/Pages/Post.cshtml");
        // Admin
        public IActionResult Admin() => PartialView("~/Views/MoM.Blog/Pages/Admin.cshtml");
    }
}
