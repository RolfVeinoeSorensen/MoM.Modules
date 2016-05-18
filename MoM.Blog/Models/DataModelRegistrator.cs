using MoM.Module.Interfaces;
using Microsoft.Data.Entity;

namespace MoM.Blog.Models
{
    public class DataModelRegistrator : IDataModelRegistrator
    {
        public void RegisterModels(ModelBuilder modelBuilder)
        {
            // build the model
            ModelBuilderFactory.BuildModels(modelBuilder);

            //Add data to tables
            //modelBuilder.Entity<HelloPlanet>();
        }

        //public DbSet<Post> Posts { get; set; }
        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<Category> Categories { get; set; }
    }
}
