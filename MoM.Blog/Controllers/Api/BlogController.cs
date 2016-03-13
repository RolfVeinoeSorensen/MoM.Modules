using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MoM.Blog.Interfaces;
using MoM.Module.Interfaces;
using MoM.Blog.Dtos;
using MoM.Blog.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers.Api
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IDataStorage Storage;
        private readonly IBlogService Service;

        public BlogController(IDataStorage storage)
        {
            Service = new BlogService(storage);
        }

        [HttpGet]
        [Route("categories")]
        public IList<CategoryDto> Categories()
        {
            return Service.Categories();
        }
    }
}
