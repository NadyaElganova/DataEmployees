using Microsoft.EntityFrameworkCore;

namespace DataEmployees.Models
{
    public class AppDbContext: DbContext 
    {
        public AppDbContext(DbContextOptions options) : base(options){}
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Organization> Organizations { get; set; }
    }
}
