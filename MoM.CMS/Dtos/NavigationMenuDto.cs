using System.Collections.Generic;

namespace MoM.CMS.Dtos
{
    public partial class NavigationMenuDto
    {
        public int navigationMenuId { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string iconClass { get; set; }

        public virtual List<NavigationMenuNavigationMenuItemDto> menuItems { get; set; }

        public NavigationMenuDto() { }
        public NavigationMenuDto(int NavigationMenuId, string Name, string DisplayName, string IconClass, List<NavigationMenuNavigationMenuItemDto> MenuItems) {
            navigationMenuId = NavigationMenuId;
            name = Name;
            displayName = DisplayName;
            iconClass = IconClass;
            menuItems = MenuItems;
        }
    }
}
