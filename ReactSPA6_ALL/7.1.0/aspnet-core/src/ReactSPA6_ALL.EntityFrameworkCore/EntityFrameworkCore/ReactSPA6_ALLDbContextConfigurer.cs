using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace ReactSPA6_ALL.EntityFrameworkCore
{
    public static class ReactSPA6_ALLDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ReactSPA6_ALLDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ReactSPA6_ALLDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
