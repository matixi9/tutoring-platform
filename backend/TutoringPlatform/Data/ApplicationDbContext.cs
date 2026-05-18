using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Models;

namespace TutoringPlatform.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TutoringAd>()
            .HasOne(t => t.Tutor)
            .WithMany(t => t.TutoringAds)
            .HasForeignKey(t => t.TutorId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lesson>()
            .HasOne(l => l.TutoringAd)
            .WithMany(l => l.Lessons)
            .HasForeignKey(l => l.TutoringAdId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Lesson>()
            .HasOne(u => u.Student)
            .WithMany(u => u.BookedLessons)
            .HasForeignKey(u => u.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<TutorAvailability>()
            .HasOne(t => t.TutoringAd)
            .WithMany(t => t.TutorAvailabilities)
            .HasForeignKey(t => t.TutoringAdId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<TutoringAd> TutoringAds { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<TutorAvailability> TutorAvailabilities { get; set; }
}