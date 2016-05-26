using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using MoM.Blog.Models;
using Microsoft.Extensions.Options;
using MoM.Module.Config;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace MoM.Blog
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        IOptions<SiteSettings> SiteSettings;

        public Startup(IHostingEnvironment env, IOptions<SiteSettings> siteSettings)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.WebRootPath)
                .AddJsonFile("../../MoM/MoM.Web/appsettings.json");

            Configuration = builder.Build();
            SiteSettings = siteSettings;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Site:ConnectionString"]));
        }
        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
