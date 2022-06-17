using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ReactSPA6_ALL.Configuration;
using ReactSPA6_ALL.Web;

namespace ReactSPA6_ALL.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class ReactSPA6_ALLDbContextFactory : IDesignTimeDbContextFactory<ReactSPA6_ALLDbContext>
    {
        public ReactSPA6_ALLDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ReactSPA6_ALLDbContext>();
            
            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            ReactSPA6_ALLDbContextConfigurer.Configure(builder, configuration.GetConnectionString(ReactSPA6_ALLConsts.ConnectionStringName));

            return new ReactSPA6_ALLDbContext(builder.Options);
        }
    }
}
