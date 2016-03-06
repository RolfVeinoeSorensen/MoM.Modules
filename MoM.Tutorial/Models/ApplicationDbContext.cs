using Microsoft.Data.Entity;

namespace MoM.Tutorial.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelBuilderFactory.BuildModels(modelBuilder);
        }
    }
}
