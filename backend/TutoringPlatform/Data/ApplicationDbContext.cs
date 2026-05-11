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
    }

    public DbSet<User> Users { get; set; }  
    public DbSet<TutoringAd> TutoringAds { get; set; }
}