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


        public IEnumerable<NavigationMenuItemDto> GetMenuItemsByMenuNameAndMenuItemId(string name, int id)
        {
            var menu = Storage.GetRepository<INavigationMenuRepository>().Fetch(m => m.Name == name).FirstOrDefault();
            if (menu == null)
            {
                return null;
            }
            var currentItem = Storage.GetRepository<INavigationMenuItemRepository>()
                                .Fetch(i => i.NavigationMenuItemId == id 
                                && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId).FirstOrDefault();
            var result = new List<NavigationMenuItemDto>();
            var parentItem = currentItem != null 
                                && currentItem.Parent != null 
                                && currentItem.Parent.NavigationMenu.NavigationMenuId == menu.NavigationMenuId 
                                ? currentItem.Parent : null;
            var menuItems = parentItem == null ?
                //root level present siblings
                Storage.GetRepository<INavigationMenuItemRepository>().Fetch(i => i.Parent == null 
                        && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId)
                    .OrderBy(x => x.SortOrder).ToDTOs() 
                :
                //not root level present children
                Storage.GetRepository<INavigationMenuItemRepository>().Fetch(
                            i => i.Parent != null 
                            && i.Parent.NavigationMenuItemId == currentItem.NavigationMenuItemId 
                            && i.NavigationMenu.NavigationMenuId == menu.NavigationMenuId)
                    .OrderBy(x => x.SortOrder).ToDTOs(); 
            if(menuItems == null) //has no children present siblings
            {
                menuItems = Storage.GetRepository<INavigationMenuItemRepository>().Fetch(i => i.Parent != null && i.Parent.NavigationMenuItemId == currentItem.Parent.NavigationMenuItemId).OrderBy(x => x.SortOrder).ToDTOs();
            }
            if (parentItem != null)
            {
                var parentDto = parentItem.ToDTO();
                parentDto.isParent = true;
                parentDto.iconClass = "fa fa-level-up";
                result.Add(parentDto);
            }
            foreach(var item in menuItems)
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
