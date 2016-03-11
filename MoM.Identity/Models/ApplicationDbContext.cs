using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using MoM.Module.Models;

namespace MoM.Identity.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelBuilderFactory.BuildModels(modelBuilder);
        }
    }
}
