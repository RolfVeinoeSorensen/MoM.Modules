using System;
using System.Collections.Generic;
using MoM.CMS.Interfaces;
using MoM.CMS.Models;
using MoM.Module.Base;

namespace MoM.CMS.Repositories
{
    public class NavigationMenuNavigationMenuItemRepository : RepositoryBase<NavigationMenuNavigationMenuItem>, INavigationMenuNavigationMenuItemRepository
    {
        public IEnumerable<NavigationMenuNavigationMenuItem> Table()
        {
            return DbSet;
        }
    }
}
