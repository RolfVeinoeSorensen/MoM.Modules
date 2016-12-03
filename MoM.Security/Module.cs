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
using Microsoft.AspNetCore.Authorization;

namespace MoM.Security
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
                    name = "Security",
                    description = "This module controls account, roles and claims in MoM.",
                    authors = "Rolf Veinø Sørensen",
                    iconCss = "fa fa-magic",
                    type = ModuleType.Core,
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
                    connectionStringPropertyInfo.SetValue(null, Configuration.GetConnectionString("DefaultConnection"));

                PropertyInfo assembliesPropertyInfo = type.GetProperty("Assemblies");

                if (assembliesPropertyInfo != null)
                    assembliesPropertyInfo.SetValue(null, ExtensionManager.Assemblies);

                services.AddScoped(typeof(IDataStorage), type);
            }

        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("Blog", "blog/{controller}/{action}", new { controller = "Blog/Pages", action = "Blog" });
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

        public void CreatePolicies(AuthorizationOptions options)
        {
            //throw new NotImplementedException();
        }
    }
}
