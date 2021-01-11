using Microsoft.EntityFrameworkCore;

namespace phonebook.Models
{
    public class PhoneBookDbContext : DbContext
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}