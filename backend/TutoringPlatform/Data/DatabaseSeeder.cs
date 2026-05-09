using Microsoft.EntityFrameworkCore;
using TutoringPlatform.Models;
using TutoringPlatform.Services;

namespace TutoringPlatform.Data;

public class DatabaseSeeder
{
    public static async Task SeedAsync(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        var passwordHasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        await context.Database.MigrateAsync();

        if (await context.Users.AnyAsync())
        {
            return;
        }

        var testUsers = new List<User>
        {
            new User
            {
                Email = "will@gmail.com",
                Name = "Will Smith",
                Password = passwordHasher.Hash("12345678"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "JohnPork@gmail.com",
                Name = "John Pork",
                Password = passwordHasher.Hash("ZAQ!2wsx"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "edekZgredek@wp.pl",
                Name = "Edzio",
                Password = passwordHasher.Hash("nONWID#(*7gg7f"),
                Role = UserRole.Student
            },

            new User
            {
                Email = "Carlito@gmail.com",
                Name = "Carl Johnson",
                Password = passwordHasher.Hash("99v3bvb8"),
                Role = UserRole.Tutor
            },

            new User
            {
                Email = "Paker@op.pl",
                Name = "Paty Kerry",
                Password = passwordHasher.Hash("12345678"),
                Role = UserRole.Tutor
            }
        };

        await context.Users.AddRangeAsync(testUsers);
        await context.SaveChangesAsync();
    }
}