using MoM.Module.Interfaces;
using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MoM.Module.Managers;

namespace MoM.Tutorial
{
    public class Module : IModule
    {
        public string Name
        {
            get
            {
                return "Tutorial - Hello Planets";
            }
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

                //if (connectionStringPropertyInfo != null)
                //    connectionStringPropertyInfo.SetValue(null, "Data Source=../db.sqlite");

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

        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            //throw new NotImplementedException();
        }

        private Type GetIStorageImplementationType()
        {
            foreach (Assembly assembly in ModuleManager.GetAssemblies)
                foreach (Type type in assembly.GetTypes())
                    if (typeof(IDataStorage).IsAssignableFrom(type) && type.GetTypeInfo().IsClass)
                        return type;

            return null;
        }
    }
}
