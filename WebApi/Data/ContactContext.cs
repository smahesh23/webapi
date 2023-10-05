using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Data
{
    public class ContactContext :DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { } 

        public DbSet<Contact> Contacts { get; set; }
    }
}
