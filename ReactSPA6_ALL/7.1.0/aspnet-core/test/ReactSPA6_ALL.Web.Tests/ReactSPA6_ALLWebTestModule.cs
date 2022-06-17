using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ReactSPA6_ALL.EntityFrameworkCore;
using ReactSPA6_ALL.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ReactSPA6_ALL.Web.Tests
{
    [DependsOn(
        typeof(ReactSPA6_ALLWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ReactSPA6_ALLWebTestModule : AbpModule
    {
        public ReactSPA6_ALLWebTestModule(ReactSPA6_ALLEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReactSPA6_ALLWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ReactSPA6_ALLWebMvcModule).Assembly);
        }
    }
}