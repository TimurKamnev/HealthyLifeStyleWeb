using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudentManager.Backend.Entiries;
using StudentManager.Backend.Entities;

namespace StudentManager.Backend.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> ctx) : base(ctx)
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ShortenUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("ConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentsSkills>()
                .HasKey(sk => new { sk.StudentId, sk.SkillId});

            modelBuilder.Entity<StudentsSkills>()
                .HasOne(sk => sk.Student)
                .WithMany(sk => sk.StudentsSkills)
                .HasForeignKey(sk => sk.StudentId);

            modelBuilder.Entity<StudentsSkills>()
                .HasOne(sk => sk.Skill)
                .WithMany(sk => sk.StudentsSkills)
                .HasForeignKey(sk => sk.SkillId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
