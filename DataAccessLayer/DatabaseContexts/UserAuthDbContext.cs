using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.DatabaseContexts
{
    public class UserAuthDbContext :IdentityDbContext
    {
        public UserAuthDbContext(DbContextOptions<UserAuthDbContext> dbContextOptions) :base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
