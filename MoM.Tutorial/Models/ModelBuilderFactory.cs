using Microsoft.Data.Entity;

namespace MoM.Tutorial.Models
{
    public class ModelBuilderFactory
    {
        public static void BuildModels(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HelloPlanet>().ForSqlServerToTable("HelloPlanet", "Tutorial");
            //Custom properties should be set here

        }
        // Add the entities here so EF7 can create auto migrations
        public DbSet<HelloPlanet> HelloPlanets { get; set; }
    }
}
