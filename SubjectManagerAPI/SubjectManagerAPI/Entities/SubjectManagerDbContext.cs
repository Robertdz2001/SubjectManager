using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SubjectManagerAPI.Entities
{
    public class SubjectManagerDbContext : DbContext
    {
        private string _connectionString =
             "Server=localhost\\SQLEXPRESS;Database=SubjectManagerDb;Trusted_Connection=True;";
        public DbSet<User> Users { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<LearningMaterial> LearningMaterials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired();

            modelBuilder.Entity<Subject>()
                .Property(s => s.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Subject>()
                .Property(s => s.ShortName)
                .HasMaxLength(10)
                .IsRequired();

            modelBuilder.Entity<Test>()
                .Property(t => t.Name)
                .HasMaxLength(70)
                .IsRequired();

            modelBuilder.Entity<LearningMaterial>()
                .Property(l => l.Name)
                .HasMaxLength(70)
                .IsRequired();

            modelBuilder.Entity<LearningMaterial>()
                .Property(l => l.Source)
                .IsRequired();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
