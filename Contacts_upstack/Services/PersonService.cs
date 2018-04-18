using Contacts_upstack.Data;
using Contacts_upstack.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts_upstack.Services
{
    public class PersonService : IPersonService
    {
        private readonly ContactsContext _context;

        public PersonService(ContactsContext context)
        {
            _context = context;
        }

        public async Task<IList<Person>> GetAllContacts()
        {
            return await _context.Persons.ToListAsync();
        }

        public async Task<Person> GetSingleContact(int? id)
        {
            return await _context.Persons.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<int> SaveContact(Person person)
        {
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return person.Id;
        }

        public async Task<int> EditContact(Person person)
        {
            var id = person.Id;

            _context.Persons.Attach(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return 0;
                }
                throw;
            }

            return id;
        }
        
        public async Task DeleteContact(Person person)
        {
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.Id == id);
        }
    }
}
