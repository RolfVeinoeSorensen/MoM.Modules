using System.Collections.Generic;

namespace MoM.CMS.Dtos
{
    public partial class NavigationMenuDto
    {
        public int navigationMenuId { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public string iconClass { get; set; }

        public NavigationMenuDto() { }
        public NavigationMenuDto(int NavigationMenuId, string Name, string DisplayName, string IconClass) {
            navigationMenuId = NavigationMenuId;
            name = Name;
            displayName = DisplayName;
            iconClass = IconClass;
        }
    }
}
