using MoM.CMS.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.CMS.Interfaces
{
    public interface INavigationMenuNavigationMenuItemRepository : IDataRepository
    {
        IEnumerable<NavigationMenuNavigationMenuItem> Table();
    }
}
