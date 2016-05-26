using Microsoft.EntityFrameworkCore;


namespace MoM.CMS.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //ModelBuilderFactory.BuildModels(modelBuilder);
        }
    }
}
