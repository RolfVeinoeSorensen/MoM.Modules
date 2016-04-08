using MoM.CMS.Models;
using MoM.Module.Interfaces;
using System.Collections.Generic;

namespace MoM.CMS.Interfaces
{
    public interface INavigationMenuItemRepository : IDataRepository
    {
        IEnumerable<NavigationMenuItem> Table();
    }
}
