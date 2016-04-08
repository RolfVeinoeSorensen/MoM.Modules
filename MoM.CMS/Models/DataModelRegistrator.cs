using MoM.Module.Interfaces;
using Microsoft.Data.Entity;

namespace MoM.CMS.Models
{
    public class DataModelRegistrator : IDataModelRegistrator
    {
        public void RegisterModels(ModelBuilder modelBuilder)
        {
            // build the model
            modelBuilder.Entity<NavigationMenu>();
            modelBuilder.Entity<NavigationMenuItem>();

            modelBuilder.Entity<NavigationMenuNavigationMenuItem>()
                .HasKey(t => new { t.NavigationMenuId, t.NavigationMenuItemId });

            modelBuilder.Entity<NavigationMenuNavigationMenuItem>()
                .HasOne(pt => pt.NavigationMenu)
                .WithMany(p => p.MenuItems)
                .HasForeignKey(pt => pt.NavigationMenuId);

            modelBuilder.Entity<NavigationMenuNavigationMenuItem>()
                .HasOne(pt => pt.NavigationMenuItem)
                .WithMany(t => t.MenuItems)
                .HasForeignKey(pt => pt.NavigationMenuItemId);

            //Add data to tables
            //modelBuilder.Entity<HelloPlanet>();
        }
    }
}
