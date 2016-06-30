using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoM.Module.Dtos;
using MoM.Module.Enums;
using MoM.Module.Interfaces;
using MoM.Module.Managers;
using System;
using System.Reflection;

namespace MoM.ModuleRepository
{
    public class Module : IModule
    {
        private IConfiguration Configuration;
        private DataStorageManager StorageManager;

        public ModuleInfoDto Info
        {
            get
            {
                return new ModuleInfoDto
                {
                    name = "Setup",
                    description = "This module helps to install and configure your MoM Website. The module will deactivate when setup is complete.",
                    authors = "Rolf Veinø Sørensen",
                    iconCss = "fa fa-magic",
                    type = ModuleType.CoreInstaller,
                    versionMajor = 1,
                    versionMinor = 0,
                    loadPriority = -1 //highest load this module any others
                };
            }
        }

        public void SetConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration GetConfiguration()
        {
            return Configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Type type = GetIStorageImplementationType();

            if (type != null)
            {
                PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

                if (connectionStringPropertyInfo != null)
                    connectionStringPropertyInfo.SetValue(null, Configuration.GetConnectionString("DefaultConnection"));

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, ExtensionManager.Assemblies);

                services.AddScoped(typeof(IDataStorage), type);
            }

        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default", "{controller=SetupApp}/{action=Index}/{id?}");
            //routeBuilder.MapRoute("default", "Setup/{controller=App}/{action=Index}");
            //routeBuilder.MapRoute("default", "{controller=setup}/{action=Index}/{id?}");
            //routeBuilder.MapRoute("default", "setup/{controller}/{action}", new { controller = "app", action = "Index" });
            routeBuilder.MapRoute("setuppages", "setup/{controller}/{action}", new { controller = "pages", action = "Outlet" });

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

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            //throw new NotImplementedException();
        }
    }
}
