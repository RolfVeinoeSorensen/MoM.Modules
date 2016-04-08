using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using MoM.CMS.Interfaces;
using MoM.CMS.Services;
using MoM.CMS.Dtos;
using MoM.Module.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers.Api
{
    [Route("api/cms/[controller]")]
    public class NavigationMenuController : Controller
    {
        private IDataStorage Storage;
        private readonly INavigationMenuService Service;

        public NavigationMenuController(IDataStorage storage)
        {
            Service = new NavigationMenuService(storage);
        }

        [HttpGet("{id}")]
        [Route("getmenuitemsbyid")]
        public IEnumerable<NavigationMenuItemDto> GetMenuItemsById(int id)
        {
            return Service.GetMenuItemsById(id);
        }
    }
}
