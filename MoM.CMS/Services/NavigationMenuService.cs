using MoM.CMS.Interfaces;
using System.Collections.Generic;
using System.Linq;
using MoM.CMS.Dtos;
using MoM.Module.Interfaces;

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
            return Storage.GetRepository<INavigationMenuRepository>().Table().FirstOrDefault(n => n.Name.Equals(name)).ToDTO();
        }

        public IEnumerable<NavigationMenuItemDto> GetMenuItemsById(int id)        {
            var result = new List<NavigationMenuItemDto>();
            var currentItem = Storage.GetRepository<INavigationMenuItemRepository>().Table().FirstOrDefault(i => i.NavigationMenuItemId == id).ToDTO();
            var parentItem = currentItem.parent == null ? null : Storage.GetRepository<INavigationMenuItemRepository>().Table().FirstOrDefault(i => i.NavigationMenuItemId == currentItem.parent.navigationMenuItemId).ToDTO();
            var siblingItems = currentItem.parent == null ?
                Storage.GetRepository<INavigationMenuItemRepository>().Table().Where(i => i.Parent == null).ToDTOs() //root level get the items on the same level
                :
                Storage.GetRepository<INavigationMenuItemRepository>().Table().Where(i => i.Parent != null && i.Parent.NavigationMenuItemId == currentItem.parent.navigationMenuItemId).ToDTOs(); //lower
            if(parentItem != null)
            {
                parentItem.isParent = true;
                parentItem.iconClass = "fa fa-level-up";
                result.Add(parentItem);                
            }
            foreach(var item in siblingItems)
            {
                result.Add(item);
            }
            return result;
        }

        public IEnumerable<NavigationMenuDto> GetMenus()
        {
            return Storage.GetRepository<INavigationMenuRepository>().Table().ToDTOs();
        }
    }
}
