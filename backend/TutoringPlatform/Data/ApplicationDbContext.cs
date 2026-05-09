using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Models;

namespace TutoringPlatform.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
}