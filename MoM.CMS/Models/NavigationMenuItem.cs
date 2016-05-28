using MoM.Module.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.CMS.Models
{
    [Table("NavigationMenuItem", Schema = "Core")]
    public partial class NavigationMenuItem : IDataEntity
    {
        public int NavigationMenuItemId { get; set; }
        public NavigationMenuItem Parent { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string DisplayName { get; set; }
        public string RouterLink { get; set; }
        [StringLength(100)]
        public string IconClass { get; set; }

        public int SortOrder { get; set; }

        public int? ParentNavigationMenuItemId { get; set; }

        public int NavigationMenuId { get; set; }
        public NavigationMenu NavigationMenu { get; set; }
    }
}
