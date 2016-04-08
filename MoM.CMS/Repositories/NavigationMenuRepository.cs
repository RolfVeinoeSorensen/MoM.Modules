using System.Collections.Generic;
using MoM.CMS.Interfaces;
using MoM.CMS.Models;
using MoM.Module.Base;

namespace MoM.CMS.Repositories
{
    public class NavigationMenuRepository : RepositoryBase<NavigationMenu>, INavigationMenuRepository
    {
        public IEnumerable<NavigationMenu> Table()
        {
            return DbSet;
        }
    }
}
