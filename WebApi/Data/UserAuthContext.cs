using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class UserAuthContext : IdentityDbContext
    {
        public UserAuthContext(DbContextOptions<UserAuthContext> dbContextOptions) : base(dbContextOptions) { }        
        public DbSet<User> Users { get; set; }
    }   
}
