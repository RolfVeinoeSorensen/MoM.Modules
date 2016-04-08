using System;
using System.Collections.Generic;
using MoM.CMS.Interfaces;
using MoM.CMS.Models;
using MoM.Module.Base;

namespace MoM.CMS.Repositories
{
    public class NavigationMenuItemRepository : RepositoryBase<NavigationMenuItem>, INavigationMenuItemRepository
    {
        public IEnumerable<NavigationMenuItem> Table()
        {
            return DbSet;
        }
    }
}
