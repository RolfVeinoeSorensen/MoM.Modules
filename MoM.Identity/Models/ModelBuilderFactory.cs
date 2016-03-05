using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace MoM.Identity.Models
{
    public static class ModelBuilderFactory
    {
        public static void BuildModels(ModelBuilder modelBuilder)
        {
            
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            const string IdentitySchema = "Identity";
            modelBuilder.Entity<ApplicationUser>().ToTable("User", IdentitySchema).Property(p => p.Id).HasColumnName("UserId");
            modelBuilder.Entity<IdentityRole>().ToTable("Role", IdentitySchema).Property(p => p.Id).HasColumnName("RoleId");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", IdentitySchema);
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", IdentitySchema);
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", IdentitySchema);
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole", IdentitySchema);
        }
    }
}
