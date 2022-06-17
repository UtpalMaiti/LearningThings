using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ReactSPA6_ALL.Authorization;

namespace ReactSPA6_ALL
{
    [DependsOn(
        typeof(ReactSPA6_ALLCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ReactSPA6_ALLApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ReactSPA6_ALLAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ReactSPA6_ALLApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
