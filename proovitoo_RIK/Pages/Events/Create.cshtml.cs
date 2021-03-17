using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using abc.Facade.Models;
using abc.Infra.Data;

namespace abc.proovitoo_RIK.Pages.Events
{
    public class CreateModel : PageModel
    {
        private readonly EventsDbContext _context;

        public CreateModel(EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await CreateEvent();

            return RedirectToPage("../Index");
        }

        public async Task CreateEvent()
        {
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();
        }
    }
}
