using Microsoft.EntityFrameworkCore;
using WebAppContacts.Server.Entities;

namespace WebAppContacts.Server.Data
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { } //options will be passed in Program.cs
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactCategory> Categories { get; set; }
        public DbSet<ContactSubcategory> Subcategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactCategory>().HasData(
                new ContactCategory { Id = 1, Name = "Business" },
                new ContactCategory { Id = 2, Name = "Private"},
                new ContactCategory { Id = 3, Name = "Other"}
                );
            modelBuilder.Entity<ContactSubcategory>().HasData(
                new ContactSubcategory { Id = 1, Name = "Boss"},
                new ContactSubcategory { Id = 2, Name = "Client" }
                );
            modelBuilder.Entity<Contact>()
                .HasIndex(x => x.Email)
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
