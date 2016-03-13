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

namespace MoM.Tutorial
{
    public class Module : IModule
    {
        private IConfiguration Configuration;
        private DataStorageManager StorageManager;
        public string Name
        {
            get
            {
                return "Tutorial";
            }
        }

        public ExtensionType Type
        {
            get
            {
                return ExtensionType.Module;
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
                    connectionStringPropertyInfo.SetValue(null, Configuration["Data:DefaultConnection:ConnectionString"]);

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, AssemblyManager.GetAssemblies);

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
