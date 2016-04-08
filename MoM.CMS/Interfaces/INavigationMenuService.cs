using MoM.CMS.Dtos;
using System.Collections.Generic;

namespace MoM.CMS.Interfaces
{
    public interface INavigationMenuService
    {
        IEnumerable<NavigationMenuDto> GetMenus();
        NavigationMenuDto GetMenuByName(string name);
        IEnumerable<NavigationMenuItemDto> GetMenuItemsById(int id);
    }
}
