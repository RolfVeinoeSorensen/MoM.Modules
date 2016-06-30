using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using MoM.Module.Enums;
using MoM.Module.Dtos;
using System.Data.SqlClient;
using MoM.Module.Interfaces;
using Microsoft.AspNetCore.Identity;
using MoM.Module.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoM.Module.Services;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MoM.Setup.Controllers.Api
{
    public class SetupController : Controller
    {
        private IDataStorage Storage;
        IOptions<SiteSettingDto> SiteSetting;
        private IConfiguration Configuration { get; set; }
        IHostingEnvironment Host;
        private InstallationStatus InstallStatus { get; set; }
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly IIdentityService IdentityService;
        private readonly ILogger Logger;

        public SetupController(
            IDataStorage storage,
            IOptions<SiteSettingDto> siteSetting, 
            IHostingEnvironment host, 
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            ILoggerFactory loggerFactory
            )
        {
            Storage = storage;
            SiteSetting = siteSetting;
            Host = host;
            Configuration = configuration;
            InstallStatus = (InstallationStatus)int.Parse(configuration["InstallStatusMoM"]);
            UserManager = userManager;
            RoleManager = roleManager;
            Logger = loggerFactory.CreateLogger<SetupController>();
            IdentityService = new IdentityService(UserManager, RoleManager, Logger);
        }

        [HttpGet]
        [Route("api/setup/init")]
        public SiteSettingInstallationStatusDto Init()
        {
            return new SiteSettingInstallationStatusDto {
                message = "init",
                installationResultCode = Result.Success.ToString(),
                installationStatus = InstallStatus,
                siteSetting = SiteSetting.Value
            };
        }

        [HttpGet]
        [Route("api/setup/getconnectionstring")]
        public SiteSettingConnectionStringDto GetConnectionString()
        {
            var filepath = Host.ContentRootPath + "\\" + "appsettings.json";
            var appsettingsFile = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText(filepath));
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            if (InstallStatus != InstallationStatus.MissingConnectionString && InstallStatus != InstallationStatus.Installed)
            {
                builder = new SqlConnectionStringBuilder(appsettingsFile.ConnectionStrings.DefaultConnection.Value);
            }

            var result = new SiteSettingConnectionStringDto
            {
                database = builder.InitialCatalog,
                server = builder.DataSource,
                useWindowsAuthentication = builder.IntegratedSecurity,
                password = builder.Password,
                username = builder.UserID
            };
            
            return result;
        }

        [HttpPost]
        [Route("api/setup/saveconnectionstring")]
        public SiteSettingInstallationStatusDto SaveConnectionstring([FromBody] SiteSettingConnectionStringDto connectionstring)
        {
            if(InstallStatus == InstallationStatus.Installed)
            {
                return new SiteSettingInstallationStatusDto
                {
                    installationStatus = InstallStatus,
                    message = "MoM is allready installed. Please use the admin interface to alter them.",
                    installationResultCode = Result.Warning.ToString()
                };
            }
            var filepath = Host.ContentRootPath + "\\" + "appsettings.json";
            var appsettingsFile = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText(filepath));
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = connectionstring.server;
            builder.InitialCatalog = connectionstring.database;
            builder.IntegratedSecurity = connectionstring.useWindowsAuthentication;
            if(!connectionstring.useWindowsAuthentication)
            {
                builder.Password = connectionstring.password;
                builder.UserID = connectionstring.username;
            }
            builder.MultipleActiveResultSets = true;
            appsettingsFile.ConnectionStrings.DefaultConnection = builder.ConnectionString;
            appsettingsFile.InstallStatusMoM = ((int)InstallationStatus.DatabaseCreated).ToString();
            System.IO.File.WriteAllText(filepath, JsonConvert.SerializeObject(appsettingsFile));

            //Todo apply migrations to the database
            return new SiteSettingInstallationStatusDto {
                installationStatus = InstallationStatus.DatabaseCreated,
                message = "The connectionstring to the database have been saved",
                installationResultCode = Result.Success.ToString()};
        }

        [HttpPost]
        [Route("api/setup/createadmin")]
        public SiteSettingInstallationStatusDto CreateAdmin([FromBody] UserCreateDto user)
        {
            var adminAccountExistTask = UserManager.GetUsersInRoleAsync("Administrator");
            adminAccountExistTask.Wait();
            List<UserDto> adminAccountExist = adminAccountExistTask.Result.ToDTOs();
            if(
                InstallStatus == InstallationStatus.AdminAccountCreated 
                || InstallStatus == InstallationStatus.Installed
                || adminAccountExist.Count != 0
                )
            {
                if(InstallStatus != InstallationStatus.Installed)
                    SaveInstallationStatus(InstallationStatus.AdminAccountCreated);
                return new SiteSettingInstallationStatusDto
                {
                    message = "Admin account is allready created. Please use the admin interface to alter them.",
                    installationStatus = InstallStatus,
                    installationResultCode = Result.Error.ToString()
                };
            }
            try
            {
                var roleExist = IdentityService.GetRole("Administrator");
                roleExist.Wait();
                if (string.IsNullOrEmpty(roleExist.Result.name))
                {
                    IdentityService.CreateRole("Administrator").Wait();
                    roleExist = IdentityService.GetRole("Administrator");
                    roleExist.Wait();
                }

                var userExist = UserManager.FindByEmailAsync(user.email); //IdentityService.GetUserByEmail(user.email);
                userExist.Wait();
                if (string.IsNullOrEmpty(userExist.Result.Email))
                {
                    var userToCreate = new ApplicationUser { UserName = user.username, Email = user.email, EmailConfirmed = true };
                    IdentityService.CreateUser(userToCreate.ToDTO(), user.password).Wait();
                    userExist = UserManager.FindByEmailAsync(user.email);
                    userExist.Wait();
                }
                UserManager.AddToRoleAsync(userExist.Result, "Administrator").Wait();
            }
            catch (Exception e) {
                return new SiteSettingInstallationStatusDto
                {
                    message = e.Message,
                    installationStatus = InstallStatus,
                    installationResultCode = Result.Error.ToString()
                };
            }

            SaveInstallationStatus(InstallationStatus.AdminAccountCreated);
            return new SiteSettingInstallationStatusDto
            {
                message = "Admin account with username: " + user.username + " and email: " + user.email + ", was created",
                installationStatus = InstallationStatus.AdminAccountCreated,
                installationResultCode = Result.Success.ToString()
            };
        }

        [HttpPost]
        [Route("api/setup/setupsocial")]
        public SiteSettingInstallationStatusDto SetupSocial([FromBody]SiteSettingDto siteSetting)
        {
            if (InstallStatus == InstallationStatus.SocialLoginsConfigured)
            {
                return new SiteSettingInstallationStatusDto
                {
                    installationStatus = InstallStatus,
                    message = "Social accounts are allready configured. Please use the admin interface to alter them.",
                    installationResultCode = Result.Warning.ToString()
                };
            }
            return SaveSiteSetting(siteSetting, InstallationStatus.SocialLoginsConfigured);
        }

        [HttpPost]
        [Route("api/setup/setupmail")]
        public SiteSettingInstallationStatusDto SetupMail([FromBody]SiteSettingDto siteSetting)
        {
            if (InstallStatus == InstallationStatus.MailConfigured)
            {
                return new SiteSettingInstallationStatusDto
                {
                    installationStatus = InstallStatus,
                    message = "Mail is allready configured. Please use the admin interface to alter it.",
                    installationResultCode = Result.Warning.ToString()
                };
            }
            return SaveSiteSetting(siteSetting, InstallationStatus.MailConfigured);
        }

        [HttpPost]
        [Route("api/setup/installmodules")]
        public SiteSettingInstallationStatusDto InstallModules()
        {
            SaveInstallationStatus(InstallationStatus.ModulesSelected);
            return new SiteSettingInstallationStatusDto
            {
                message = "Sitesettings could not be saved. Most likely it is caused either because you have allready completed the installation or there is no connection to the database.",
                installationResultCode = Result.Error.ToString(),
                installationStatus = InstallationStatus.ModulesSelected
            };
        }

        protected SiteSettingInstallationStatusDto SaveSiteSetting(SiteSettingDto siteSetting, InstallationStatus installationStatus)
        {
            //TODO save SiteSetting;
            SaveInstallationStatus(installationStatus);
            return new SiteSettingInstallationStatusDto
            {
                message = "Sitesettings could not be saved. Most likely it is caused either because you have allready completed the installation or there is no connection to the database.",
                installationResultCode = Result.Error.ToString(),
                installationStatus = installationStatus,
                siteSetting = siteSetting
            };
        }

        protected void SaveInstallationStatus(InstallationStatus installationStatus)
        {
            var filepath = Host.ContentRootPath + "\\" + "appsettings.json";
            var appsettingsFile = JsonConvert.DeserializeObject<dynamic>(System.IO.File.ReadAllText(filepath));
            appsettingsFile.InstallStatusMoM = ((int)installationStatus).ToString();
            System.IO.File.WriteAllText(filepath, JsonConvert.SerializeObject(appsettingsFile));
            InstallStatus = installationStatus;
        }
    }
}
