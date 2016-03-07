using MoM.Module.Interfaces;
using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MoM.Module.Managers;
using System.Linq;
using MoM.Tutorial.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MoM.Tutorial
{
    public class Module : IModule
    {
        private IConfigurationRoot ConfigurationRoot;
        public string Name
        {
            get
            {
                return "Tutorial - Hello Planets";
            }
        }

        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            ConfigurationRoot = configurationRoot;
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            //throw new NotImplementedException();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Type type = GetIStorageImplementationType();

            if (type != null)
            {
                PropertyInfo connectionStringPropertyInfo = type.GetProperty("ConnectionString");

                if (connectionStringPropertyInfo != null)
                    connectionStringPropertyInfo.SetValue(null, this.ConfigurationRoot["Data:DefaultConnection:ConnectionString"]);

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, ModuleManager.GetAssemblies);

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
    }
}
