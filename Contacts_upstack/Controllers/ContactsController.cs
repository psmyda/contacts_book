using Contacts_upstack.Data;
using Contacts_upstack.Models;
using Contacts_upstack.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts_upstack.Controllers
{
    [Produces("application/json")]
    [Route("api/Contacts")]
    public class ContactsController : Controller
    {
        private readonly PersonService _service;

        public ContactsController(ContactsContext context)
        {
            _service = new PersonService(context);
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _service.GetAllContacts();
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _service.GetSingleContact(id);
        }

        [HttpPost]
        public async Task<Person> Save(Person person)
        {
            var id = await _service.SaveContact(person);

            return await _service.GetSingleContact(id);
        }

        [HttpPost("{id}")]
        public async Task<Person> Update(int id, Person person)
        {
            await _service.EditContact(person);

            return await _service.GetSingleContact(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var person = await _service.GetSingleContact(id);
            await _service.DeleteContact(person);
        }
    }
}