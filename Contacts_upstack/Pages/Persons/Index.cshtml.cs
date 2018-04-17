using Contacts_upstack.Data;
using Contacts_upstack.Models;
using Contacts_upstack.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Contacts_upstack.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly ContactsContext _context;
        private readonly PersonService _service;

        public IndexModel(ContactsContext context)
        {
            _context = context;
            _service = new PersonService(context);
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            Person = await _service.GetAllContacts();
        }
    }
}
