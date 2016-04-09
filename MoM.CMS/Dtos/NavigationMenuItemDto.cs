namespace MoM.CMS.Dtos
{
    public class NavigationMenuItemDto
    {
        public int navigationMenuItemId { get; set; }
        public NavigationMenuItemDto parent { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string routerLink { get; set; }
        public string iconClass { get; set; }
        public int sortOrder { get; set; }
        public NavigationMenuDto navigationMenu { get; set; }

        //custom properties not on the entity
        public bool isParent { get; set; }

        //public virtual List<NavigationMenuNavigationMenuItemDto> MenuItems { get; set; }

        public NavigationMenuItemDto() { }
        public NavigationMenuItemDto(int NavigationMenuItemId, NavigationMenuItemDto Parent, string Name, string DisplayName, string RouterLink, string IconClass, int SortOrder, NavigationMenuDto NavigationMenu, bool IsParent) {
            navigationMenuItemId = NavigationMenuItemId;
            parent = Parent;
            name = Name;
            displayName = DisplayName;
            routerLink = RouterLink;
            iconClass = IconClass;
            isParent = IsParent;
            sortOrder = SortOrder;
            navigationMenu = NavigationMenu;
        }
    }
}
