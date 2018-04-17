using Contacts_upstack.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts_upstack.Services
{
    public interface IPersonService
    {
        Task<IList<Person>> GetAllContacts();
        Task<Person> GetSingleContact(int? id);
        Task<int> SaveContact(Person person);
        Task<int> EditContact(Person person);
        Task DeleteContact(Person person);
    }
}