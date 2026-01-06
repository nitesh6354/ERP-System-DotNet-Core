using ERP.Domain.Entities;
using ERP.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;

namespace ERP.Infrastructure.Data
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(ApplicationDbContext context)
        {
            // If admin already exists, do nothing
            if (await context.Users.AnyAsync(u => u.Username == "admin"))
                return;

            var admin = new User
            {
                Username = "admin",
                PasswordHash = PasswordHasher.HashPassword("Admin@123"),
                Role = "Admin",
                IsActive = true
            };

            context.Users.Add(admin);
            await context.SaveChangesAsync();
        }
    }
}
