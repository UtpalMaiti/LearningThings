using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using ReactSPA6_ALL.EntityFrameworkCore.Seed;

namespace ReactSPA6_ALL.EntityFrameworkCore
{
    [DependsOn(
        typeof(ReactSPA6_ALLCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class ReactSPA6_ALLEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<ReactSPA6_ALLDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        ReactSPA6_ALLDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        ReactSPA6_ALLDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ReactSPA6_ALLEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
