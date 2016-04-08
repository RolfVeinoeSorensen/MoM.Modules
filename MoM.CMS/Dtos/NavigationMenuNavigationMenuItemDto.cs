namespace MoM.CMS.Dtos
{
    public partial class NavigationMenuNavigationMenuItemDto
    {
        public int navigationMenuId { get; set; }
        public NavigationMenuDto navigationMenu { get; set; }

        public int navigationMenuItemId { get; set; }
        public NavigationMenuItemDto navigationMenuItem { get; set; }

        public NavigationMenuNavigationMenuItemDto() { }

        public NavigationMenuNavigationMenuItemDto(int NavigationMenuId, NavigationMenuDto NavigationMenu, int NavigationMenuItemId, NavigationMenuItemDto NavigationMenuItem)
        {
            navigationMenuId = NavigationMenuId;
            navigationMenu = NavigationMenu;

            navigationMenuItemId = NavigationMenuItemId;
            navigationMenuItem = NavigationMenuItem;
        }
    }
}
