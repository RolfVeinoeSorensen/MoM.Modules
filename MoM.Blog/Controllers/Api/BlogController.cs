using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using MoM.Blog.Interfaces;
using MoM.Module.Interfaces;
using MoM.Blog.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Blog.Controllers.Api
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        private IDataStorage Storage;

        public BlogController(IDataStorage storage)
        {
            Storage = storage;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<PostDto> Get()
        {
            return Storage.GetRepository<IPostRepository>().All().ToDTOs();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
