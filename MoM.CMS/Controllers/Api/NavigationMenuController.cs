using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoM.CMS.Interfaces;
using MoM.CMS.Services;
using MoM.CMS.Dtos;
using MoM.Module.Interfaces;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.CMS.Controllers.Api
{
    [AllowAnonymous]
    public class NavigationMenuController : Controller
    {
        private IDataStorage Storage;
        private readonly INavigationMenuService Service;

        public NavigationMenuController(IDataStorage storage)
        {
            Service = new NavigationMenuService(storage);
        }

        [HttpPost()]
        [Route("api/cms/getmenuitemsbymenunameandmenuitemid")]
        public IEnumerable<NavigationMenuItemDto> GetMenuItemsByMenuNameAndMenuItemId([FromBody] NavigationMenuRequestDto request)
        {
            return Service.GetMenuItemsByMenuNameAndMenuItemId(request.name, request.id, request.routeName);
        }
    }
}
