using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers.Blog
{
    [Route("blog/[controller]/[action]")]
    public class ComponentsController : Controller
    {
        //TODO alter the view location finder to add support for each module
        public IActionResult Index() => PartialView("~/Views/MoM.Blog/Components/Index.cshtml");
        public IActionResult Categories() => PartialView("~/Views/MoM.Blog/Components/Categories.cshtml");
    }
}
