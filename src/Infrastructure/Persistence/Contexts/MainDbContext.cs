using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Archable.Domain.Entities.Account;

namespace Archable.Infrastructure.Persistence.Contexts
{
    internal sealed class MainDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlite(configuration
                .GetConnectionString("Default"), migration => migration
                .MigrationsAssembly(typeof(MainDbContext).Assembly.FullName));
        }
    }
}