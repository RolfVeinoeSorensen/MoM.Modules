using MoM.Module.Interfaces;
using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MoM.Module.Managers;
using Microsoft.AspNet.Hosting;
using MoM.Module.Enums;
using MoM.Module.Dtos;

namespace MoM.CMS
{
    public class Module : IModule
    {
        private IConfiguration Configuration;
        private DataStorageManager StorageManager;

        public ExtensionInfoDto Info
        {
            get
            {
                return new ExtensionInfoDto
                {
                    name = "CMS",
                    description = "This module contains all you need to create a site with pages and widgets. The admin part also resides here",
                    authors = "Rolf Veinø Sørensen",
                    iconCss = "fa fa-bullhorn",
                    type = ModuleType.Module,
                    versionMajor = 1,
                    versionMinor = 0
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

        public void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {

        }

        public void ConfigureServices(IServiceCollection services)
        {
            Type type = GetIStorageImplementationType();

            if (type != null)
            {
                PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

                if (connectionStringPropertyInfo != null)
                    connectionStringPropertyInfo.SetValue(null, Configuration["Site:ConnectionString"]);

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, AssemblyManager.GetAssemblies);

                services.AddScoped(typeof(IDataStorage), type);
            }

        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("CMS", "cms/{controller}/{action}", new { controller = "CMS/Pages", action = "Home" });
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
