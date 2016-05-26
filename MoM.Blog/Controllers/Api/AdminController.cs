using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoM.Blog.Dtos;
using MoM.Module.Interfaces;
using MoM.Blog.Services;
using MoM.Blog.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers.Api
{
    [Route("api/blog/[controller]")]
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

        [HttpPut]
        [Route("createpost")]
        public void CreatePost([FromBody]PostDto post)
        {
            Service.CreatePost(post);
        }

        [HttpPut]
        [Route("updatepost")]
        public void UpdatePost([FromBody]PostDto post)
        {
            Service.UpdatePost(post);
        }

        [HttpPut]
        [Route("deletepost")]
        public void DeletePost([FromBody]PostDto post)
        {
            Service.DeletePost(post);
        }

        [HttpGet("{pageNo}/{pageSize}/{sortColumn}/{sortByAscending}")]
        [Route("categories")]
        public IEnumerable<CategoryDto> Categories(int pageNo, int pageSize, string sortColumn, bool sortByAscending)
        {
            return Service.CategoriesWithPostCount(pageNo, pageSize, sortColumn, sortByAscending);
        }

        [HttpPut]
        [Route("createcategory")]
        public void CreateCategory([FromBody]CategoryDto category)
        {
            Service.CreateCategory(category);
        }

        [HttpPut]
        [Route("updatecategory")]
        public void UpdateCategory([FromBody]CategoryDto category)
        {
            Service.UpdateCategory(category);
        }

        [HttpPut]
        [Route("deletecategory")]
        public void DeleteCategory([FromBody]CategoryDto category)
        {
            Service.DeleteCategory(category);
        }

        [HttpPut]
        [Route("createtag")]
        public void CreateTag([FromBody]TagDto tag)
        {
            Service.CreateTag(tag);
        }

        [HttpPut]
        [Route("updatetag")]
        public void UpdateTag([FromBody]TagDto tag)
        {
            Service.UpdateTag(tag);
        }

        [HttpPut]
        [Route("deletetag")]
        public void DeleteTag([FromBody]TagDto tag)
        {
            Service.DeleteTag(tag);
        }

    }
}
