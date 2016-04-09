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

            //Add data to tables
            //modelBuilder.Entity<HelloPlanet>();
        }
    }
}
