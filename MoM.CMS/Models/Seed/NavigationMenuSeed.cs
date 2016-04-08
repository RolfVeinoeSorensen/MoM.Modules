using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoM.CMS.Models.Seed
{
    public class NavigationMenuSeed
    {
        public void Seed()
        {

        }

        public readonly static IEnumerable<NavigationMenu> NavigationMenus = new List<NavigationMenu>
        {
            new NavigationMenu { Name="Main",DisplayName="Main menu for top navigation", IconClass="fa fa-home" },
            new NavigationMenu { Name="Admin", DisplayName="Administration navigation for sidebar", IconClass="fa fa-server" }
        };
    }
}
