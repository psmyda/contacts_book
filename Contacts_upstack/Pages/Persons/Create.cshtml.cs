using Contacts_upstack.Data;
using Contacts_upstack.Models;
using Contacts_upstack.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Contacts_upstack.Pages.Persons
{
    public class CreateModel : PageModel
    {
        private readonly ContactsContext _context;
        private readonly PersonService _service;

        public CreateModel(ContactsContext context)
        {
            _context = context;
            _service = new PersonService(context);
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var result = await _service.SaveContact(Person);

            if (result == 0)
                return Unauthorized();

            return RedirectToPage("./Index");
        }
    }
}