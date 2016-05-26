using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MoM.Module.Interfaces;
using MoM.Tutorial.Interfaces;
using MoM.Tutorial.Dtos;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Tutorial.Controllers.Api
{
    [Route("api/[controller]")]
    public class TutorialController : Controller
    {
        private IDataStorage Storage;

        public TutorialController(IDataStorage storage)
        {
            Storage = storage;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<HelloPlanetDto> Get()
        {
            Storage.GetRepository<IHelloPlanetRepository>().Init();
            return Storage.GetRepository<IHelloPlanetRepository>().All().ToDTOs();
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
