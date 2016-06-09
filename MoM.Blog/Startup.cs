using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Infrastructure;
using MoM.Module.Models;
using MoM.Module.Config;

namespace MoM.Blog
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }
        IOptions<SiteSetting> SiteSetting;

        public Startup(IHostingEnvironment env, IOptions<SiteSetting> siteSetting)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.WebRootPath)
                .AddJsonFile("../../MoM/MoM.Web/appsettings.json");

            Configuration = builder.Build();
            SiteSetting = siteSetting;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddDbContext<Models.ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
        public void Configure(IApplicationBuilder app)
        {
        }
    }
}
