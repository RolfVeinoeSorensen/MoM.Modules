using MoM.Module.Interfaces;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MoM.Module.Managers;
using Microsoft.AspNetCore.Hosting;
using MoM.Module.Enums;
using MoM.Module.Dtos;

namespace MoM.Tutorial
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
                    name = "Tutorial",
                    description = "This module contains the basic methods and examples you need as a module developer to get started.",
                    authors = "Rolf Veinø Sørensen",
                    iconCss = "fa fa-graduation-cap",
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
                    assembliesPropertyInfo.SetValue(null, ExtensionManager.Assemblies);

                services.AddScoped(typeof(IDataStorage), type);
            }

        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute(name: "Tutorial", template: "tutorial", defaults: new { controller = "Tutorial", action = "Index" });
        }

        private Type GetIStorageImplementationType()
        {
            AssemblyName a = new AssemblyName {Name = "MoM.Module" };
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
