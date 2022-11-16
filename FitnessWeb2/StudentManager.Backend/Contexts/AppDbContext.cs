using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManager.Backend.Entiries;
using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Contexts
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }
    }
}
// siteddv
