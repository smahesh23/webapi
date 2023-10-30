using Microsoft.EntityFrameworkCore;
using DataAccessLayer.DatabaseModels;
namespace DataAccessLayer.DatabaseContexts
{
    public class EmployeeDbContext :DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
