using Contacts_upstack.Data;
using Contacts_upstack.Models;
using Contacts_upstack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Contacts_upstack.Pages.Persons
{
    public class DeleteModel : PageModel
    {
        private readonly ContactsContext _context;
        private readonly PersonService _service;

        public DeleteModel(ContactsContext context)
        {
            _context = context;
            _service = new PersonService(context);
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Person = await _service.GetSingleContact(id);

            if (Person == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Person = await _service.GetSingleContact(id);

            if (Person != null)
                await _service.DeleteContact(Person);

            return RedirectToPage("./Index");
        }
    }
}
