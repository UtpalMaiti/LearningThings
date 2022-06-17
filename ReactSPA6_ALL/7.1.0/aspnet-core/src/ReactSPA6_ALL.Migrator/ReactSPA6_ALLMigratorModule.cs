using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ReactSPA6_ALL.Configuration;
using ReactSPA6_ALL.EntityFrameworkCore;
using ReactSPA6_ALL.Migrator.DependencyInjection;

namespace ReactSPA6_ALL.Migrator
{
    [DependsOn(typeof(ReactSPA6_ALLEntityFrameworkModule))]
    public class ReactSPA6_ALLMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ReactSPA6_ALLMigratorModule(ReactSPA6_ALLEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ReactSPA6_ALLMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ReactSPA6_ALLConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReactSPA6_ALLMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
