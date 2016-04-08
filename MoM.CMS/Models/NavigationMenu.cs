using MoM.Module.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoM.CMS.Models
{
    [Table("NavigationMenu", Schema = "Core")]
    public partial class NavigationMenu : IDataEntity
    {
        public int NavigationMenuId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string DisplayName { get; set; }
        [StringLength(100)]
        public string IconClass { get; set; }

        public virtual List<NavigationMenuNavigationMenuItem> MenuItems { get; set; }
    }
}
