using MoM.Module.Interfaces;
using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoM.Module.Managers;
using System.Reflection;
using MoM.Identity.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using MoM.Identity.Interfaces;
using MoM.Identity.Services;
using MoM.Identity.Middleware;
using MoM.Module.Models;
using Microsoft.Data.Entity;

namespace MoM.Identity
{
    public class Module : IModule
    {
        private IConfigurationRoot ConfigurationRoot;
        private DataStorageManager StorageManager;
        public string Name
        {
            get
            {
                return "MoM.Identity";
            }
        }

        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            ConfigurationRoot = configurationRoot;
        }

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {
            applicationBuilder.UseIdentity();

            // To configure external authentication please see http://go.microsoft.com/fwlink/?LinkID=532715
            //applicationBuilder.UseAuthorizeCorrectly();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Type type = GetIStorageImplementationType();

            if (type != null)
            {
                PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

                if (connectionStringPropertyInfo != null)
                    connectionStringPropertyInfo.SetValue(null, ConfigurationRoot["Data:DefaultConnection:ConnectionString"]);

                // Add EF services to the services container.
                services.AddEntityFramework()
                    .AddSqlServer()
                    .AddDbContext<ApplicationDbContext>(options =>
                        options.UseSqlServer(ConfigurationRoot["Data:DefaultConnection:ConnectionString"]));

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, ModuleManager.GetAssemblies);

                services.AddScoped(typeof(IDataStorage), type);

                services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                    options.Cookies.ApplicationCookie.AutomaticAuthenticate = true;
                    options.Cookies.ApplicationCookie.AutomaticChallenge = false;
                    //options.Cookies.ApplicationCookieAuthenticationScheme = "ApplicationCookie";
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

                // Add application services.
                services.AddTransient<IEmailSender, AuthMessageSender>();
                services.AddTransient<ISmsSender, AuthMessageSender>();
            }
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("accountdefault", "{controller=Account}/{action=Login}");
            routeBuilder.MapRoute("accountsub", "{controller=Account}/{action}/{id?}");
            routeBuilder.MapRoute("manage", "{controller=Manage}/{action}");
            routeBuilder.MapRoute("managesub", "{controller=Manage}/{action}/{id?}");
        }



        private Type GetIStorageImplementationType()
        {
            AssemblyName a = new AssemblyName { Name = "MoM.Module" };
            var t = Assembly.Load(a).GetTypes();
            foreach (Type type in t)
                if (typeof(IDataStorage).IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                    return type;

            return null;
        }
    }
}
