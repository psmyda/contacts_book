using Contacts_upstack.Models;
using Contacts_upstack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Contacts_upstack.Pages.Persons
{
    public class EditModel : PageModel
    {
        private readonly Data.ContactsContext _context;
        private readonly PersonService _service;

        public EditModel(Data.ContactsContext context)
        {
            _context = context;
            _service = new PersonService(context);
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Person = await _service.GetSingleContact(id);

            if (Person == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _service.EditContact(Person);

            if (result == 0)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
