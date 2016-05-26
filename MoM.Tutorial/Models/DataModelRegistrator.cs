using MoM.Module.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MoM.Tutorial.Models
{
    public class DataModelRegistrator : IDataModelRegistrator
    {
        public void RegisterModels(ModelBuilder modelBuilder)
        {
            // build the model
            ModelBuilderFactory.BuildModels(modelBuilder);
            //modelBuilder.Entity<HelloPlanet>(etb =>
            //{
            //    etb.HasKey(e => e.HelloPlanetId);
            //    etb.Property(e => e.HelloPlanetId);
            //    etb.ForSqlServerToTable("HelloPlanet", "Tutorial");
            //});
            //Add data to tables
            //modelBuilder.Entity<HelloPlanet>();
        }

        public DbSet<HelloPlanet> HelloPlanets { get; set; }
    }
}
