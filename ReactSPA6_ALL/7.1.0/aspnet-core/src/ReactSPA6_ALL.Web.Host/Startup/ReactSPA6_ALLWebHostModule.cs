using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ReactSPA6_ALL.Configuration;

namespace ReactSPA6_ALL.Web.Host.Startup
{
    [DependsOn(
       typeof(ReactSPA6_ALLWebCoreModule))]
    public class ReactSPA6_ALLWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ReactSPA6_ALLWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReactSPA6_ALLWebHostModule).GetAssembly());
        }
    }
}
