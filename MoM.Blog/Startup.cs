using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.Extensions.DependencyInjection;
using MoM.Blog.Models;
using Microsoft.Extensions.OptionsModel;
using MoM.Module.Config;

namespace MoM.Blog
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        IOptions<SiteSettings> SiteSettings;

        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv, IOptions<SiteSettings> siteSettings)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("../../MoM/MoM.Web/appsettings.json");

            Configuration = builder.Build();
            SiteSettings = siteSettings;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Site:ConnectionString"]));
        }
        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
