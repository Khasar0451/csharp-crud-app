using Microsoft.EntityFrameworkCore;
using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { } //options will be passed in Program.cs
        public DbSet<Contact> Contacts { get; set; }
    }
}
