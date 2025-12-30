using Microsoft.EntityFrameworkCore;
using ERP.Domain.Entities;

namespace ERP.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Employee> Employees => Set<Employee>();
    }
}
