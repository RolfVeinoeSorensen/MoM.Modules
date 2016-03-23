using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MoM.Blog.Interfaces;
using MoM.Module.Interfaces;
using MoM.Blog.Dtos;
using MoM.Blog.Services;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers
{
    [Route("blog/[controller]")]
    public class ApiController : Controller
    {
        private IDataStorage Storage;
        private readonly IBlogService Service;

        public ApiController(IDataStorage storage)
        {
            Service = new BlogService(storage);
        }

        [HttpGet("{pagesize}")]
        [Route("categorieswithpostcount")]
        public IList<CategoryDto> CategoriesWithPostCount(int pageSize)
        {
            return Service.CategoriesWithPostCount(pageSize);
        }

        [HttpPost]
        [Route("posts")]
        public IList<PostDto> Posts([FromBody]PagingDto paging)
        {
            return Service.Posts(paging.pageNo, paging.
                pageSize);
        }

        [HttpGet("{pagesize}")]
        [Route("tagswithpostcount")]
        public IList<TagDto> TagsWithPostCount(int pageSize)
        {
            return Service.TagsWithPostsCount(pageSize);
        }

        [HttpGet("{year}/{month}/{urlslug}")]
        [Route("post")]
        public PostDto Post(int year, int month, string urlSlug)
        {
            return Service.Post(year, month, urlSlug);
        }

        [HttpGet("{postId}")]
        [Route("adminpost")]
        public PostDto Post(int postId)
        {
            return Service.Post(postId);
        }

        [HttpPost]
        [Route("addpost")]
        public PostDto AddPost([FromBody]PostDto post)
        {
            return Service.AddPost(post);
        }

        [HttpPost]
        [Route("edit")]
        public PostDto EditPost([FromBody]PostDto post)
        {
            return Service.EditPost(post);
        }
    }
}
