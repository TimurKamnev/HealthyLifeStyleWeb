﻿using Microsoft.EntityFrameworkCore;
using StudentManager.Backend.Entities;
using StudentManager.Backend.Indentity;


namespace Fitness.Infrastracture
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<FitnessProgram> FitnessProgram { get; set; }
        public virtual DbSet<FitnessTip> FitnessTip { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<PersonFitnessProgram> PersonFitnessProgram { get; set; }
        public virtual DbSet<Achievement> Achievement { get; set; }
        public virtual DbSet<FitnessType> FitnessType { get; set; }
        public DbSet<ShortenUser> Users { get; set; }
        public DbSet<LogModel> Logs { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost;DataBase=HealthyLifeStyleDb;Trusted_Connection=True;MultipleActiveResultSets=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //many-to-many
            modelBuilder.Entity<PersonFitnessProgram>()
                .HasOne(x => x.Person)
                .WithMany(x => x.PersonFitnessPrograms)
                .HasForeignKey(x => x.PersonId);
            modelBuilder.Entity<PersonFitnessProgram>()
                .HasOne(x => x.FitnessProgram)
                .WithMany(x => x.PersonFitnessPrograms)
                .HasForeignKey(x => x.FitnessProgramId);

            //many-to-one
            modelBuilder.Entity<Person>()
                .HasMany(x => x.Achievements)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.PersonId);
            modelBuilder.Entity<Training>()
                .HasMany(x => x.Exercises)
                .WithOne(x => x.Training)
                .HasForeignKey(x => x.TrainingId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FitnessProgram>()
                .HasMany(x => x.Trainings)
                .WithOne(x => x.FitnessProgram)
                .HasForeignKey(x => x.FitnessProgramId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FitnessProgram>()
                .HasMany(x => x.FitnessTips)
                .WithOne(x => x.FitnessProgram)
                .HasForeignKey(x => x.FitnessProgramId)
                .OnDelete(DeleteBehavior.NoAction);

            //one-to-one
            modelBuilder.Entity<FitnessType>()
                .HasKey(s => s.FitnessProgramId);

            modelBuilder.Entity<FitnessProgram>()
                .HasOne(x => x.FitnessType)
                .WithOne(x => x.FitnessProgram);

        }
    }
}
