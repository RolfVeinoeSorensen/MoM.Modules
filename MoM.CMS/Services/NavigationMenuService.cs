using MoM.CMS.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MoM.CMS.Dtos;
using MoM.Module.Interfaces;
using System;

namespace MoM.CMS.Services
{
    public class NavigationMenuService : INavigationMenuService
    {
        private IDataStorage Storage;

        public NavigationMenuService(IDataStorage storage)
        {
            Storage = storage;
        }

        public NavigationMenuDto GetMenuByName(string name)
        {
            return Storage.GetRepository<INavigationMenuRepository>().Fetch(n => n.Name.Equals(name)).FirstOrDefault().ToDTO() ;
        }


        public IEnumerable<NavigationMenuItemDto> GetMenuItemsByMenuNameAndMenuItemId(string name, int id, string routeName)
        {
            var menu = Storage.GetRepository<INavigationMenuRepository>().Fetch(m => m.Name == name).FirstOrDefault();
            if (menu == null)
            {
                return null;
            }
            var currentItem = id == 0 ?
                routeName == null ? 
                Storage.GetRepository<INavigationMenuItemRepository>()
                                .Fetch(i => i.Parent == null
                                && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId).FirstOrDefault()
                                :
                                Storage.GetRepository<INavigationMenuItemRepository>()
                                .Fetch(i => i.Name == routeName
                                && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId).FirstOrDefault()
                :
                Storage.GetRepository<INavigationMenuItemRepository>()
                                .Fetch(i => i.NavigationMenuItemId == id 
                                && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId).FirstOrDefault();
            var result = new List<NavigationMenuItemDto>();
            var parentItem = currentItem != null 
                                && currentItem.ParentNavigationMenuItemId != null ? Storage.GetRepository<INavigationMenuItemRepository>()
                                    .Fetch(i => i.NavigationMenuItemId == currentItem.ParentNavigationMenuItemId
                                    && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId).FirstOrDefault()
                                : null;
            var menuItems = Storage.GetRepository<INavigationMenuItemRepository>().Fetch(
                                i => i.Parent != null 
                                && i.Parent.NavigationMenuItemId == currentItem.NavigationMenuItemId 
                                && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId)
                            .OrderBy(x => x.SortOrder).ToDTOs(); 

            if(menuItems.Count == 0) //has no children present siblings
            {
                menuItems = Storage.GetRepository<INavigationMenuItemRepository>().Fetch(i => i.NavigationMenuItemId == currentItem.ParentNavigationMenuItemId || i.ParentNavigationMenuItemId == currentItem.ParentNavigationMenuItemId).OrderBy(x => x.ParentNavigationMenuItemId).ThenBy(y => y.SortOrder).ToDTOs();
            }
            else
            {
                if (parentItem != null)
                {
                    var parentDto = parentItem.ToDTO();
                    parentDto.displayName = string.Empty;
                    parentDto.isParent = true;
                    parentDto.iconClass = "fa fa-level-up";
                    result.Add(parentDto);
                }
                result.Add(currentItem.ToDTO());
            }

            foreach (var item in menuItems)
            {
                result.Add(item);
            }
            return result;
        }

        public IEnumerable<NavigationMenuDto> GetMenus()
        {
            return Storage.GetRepository<INavigationMenuRepository>().Table().OrderByDescending(x => x.DisplayName).ToDTOs();
        }
    }
}
