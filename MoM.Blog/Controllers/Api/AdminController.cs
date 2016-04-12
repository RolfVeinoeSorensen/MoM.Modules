using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MoM.Blog.Dtos;
using MoM.Module.Interfaces;
using MoM.Blog.Services;
using MoM.Blog.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers.Api
{
    [Route("api/blog/admin/[controller]")]
    public class AdminController : Controller
    {
        private IDataStorage Storage;
        private readonly IBlogService Service;

        public AdminController(IDataStorage storage)
        {
            Service = new BlogService(storage);
        }

        [HttpPost]
        [Route("posts")]
        public IList<PostDto> Posts([FromBody]PagingWithSortDto paging)
        {
            return Service.Posts(paging.pageNo, paging.pageSize, paging.sortColumn, paging.sortByAscending);
        }
    }
}
