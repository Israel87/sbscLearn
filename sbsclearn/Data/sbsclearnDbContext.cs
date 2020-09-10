using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using sbsclearn.Data.Migrations;
using sbsclearn.Models.Entities;

namespace sbsclearn.Data
{
    public class sbsclearnDbContext : IdentityDbContext
    {
        public sbsclearnDbContext(DbContextOptions<sbsclearnDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UsersCourses>()
            .HasKey(bc => new { bc.UserID, bc.CourseID });
            modelBuilder.Entity<UsersCourses>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.UsersCourses)
                .HasForeignKey(bc => bc.UserID);
            modelBuilder.Entity<UsersCourses>()
                .HasOne(bc => bc.Course)
                .WithMany(c => c.UsersCourses)
                .HasForeignKey(bc => bc.UserID);
            base.OnModelCreating(modelBuilder);
            // Seed Data to the Newsdata table.
            modelBuilder.Seed();
        }
        public DbSet<sbsclearn.Models.Entities.Course> Course { get; set; }

        public DbSet<sbsclearn.Models.Entities.User> User { get; set; }

        public DbSet<sbsclearn.Models.Entities.CourseAttempt> CourseAttempt { get; set; }

        public DbSet<sbsclearn.Models.Entities.UsersCourses> UsersCourses { get; set; }
    }
}
