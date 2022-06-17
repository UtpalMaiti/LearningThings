using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using ReactSPA6_ALL.Authorization.Roles;
using ReactSPA6_ALL.Authorization.Users;
using ReactSPA6_ALL.MultiTenancy;

namespace ReactSPA6_ALL.EntityFrameworkCore
{
    public class ReactSPA6_ALLDbContext : AbpZeroDbContext<Tenant, Role, User, ReactSPA6_ALLDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public ReactSPA6_ALLDbContext(DbContextOptions<ReactSPA6_ALLDbContext> options)
            : base(options)
        {
        }
    }
}
