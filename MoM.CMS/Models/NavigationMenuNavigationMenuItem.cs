using MoM.Module.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoM.CMS.Models
{
    [Table("NavigationMenuNavigationMenuItem", Schema = "Core")]
    public partial class NavigationMenuNavigationMenuItem : IDataEntity
    {
        public int NavigationMenuId { get; set; }
        public NavigationMenu NavigationMenu { get; set; }

        public int NavigationMenuItemId { get; set; }
        public NavigationMenuItem NavigationMenuItem { get; set; }
    }       
}
