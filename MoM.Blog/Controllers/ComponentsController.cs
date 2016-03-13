using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers
{
    [Route("blog/[controller]")]
    public class ComponentsController : Controller
    {
        //TODO alter the view location finder to add support for each module
        public IActionResult Index() => PartialView("~/Views/Blog/Components/Index.cshtml");
    }
}
