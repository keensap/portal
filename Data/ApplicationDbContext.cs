using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KeenSap.Portal.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace KeenSap.Portal.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext():base(GetOptions())
        {
            Database.EnsureCreated();
        }

        private static DbContextOptions<ApplicationDbContext> GetOptions()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionBuilder.UseMySql(getConnectionString());
            return optionBuilder.Options;
        }

        private static string getConnectionString()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
                .AddEnvironmentVariables();

            var config = builder.Build();
            return config.GetConnectionString("DefaultConnection");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Role> Roles { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        // public DbSet<Entity> Entities { get; set; }

        // public DbSet<Action> Actions { get; set; }

        public DbSet<EntityAction> EntityActions { get; set; }

        public DbSet<Permission> Permissions { get; set; }
    }
}
