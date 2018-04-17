using Contacts_upstack.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts_upstack.Data
{
    public class ContactsContext : DbContext
    {
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("tblPersons");
        }
    }
}
