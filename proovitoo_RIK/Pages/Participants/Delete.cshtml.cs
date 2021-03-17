using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using abc.Facade.Models;
using abc.Infra.Data;

namespace abc.proovitoo_RIK.Pages.Participants
{
    public class DeleteModel : PageModel
    {
        private readonly EventsDbContext _context;

        public DeleteModel(EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participants
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Event)
                .AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Participant == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Participant = await _context.Participants.FindAsync(id);

            if (Participant != null)
            {
                await RemoveParticipant();
            }

            return RedirectToPage("../Index");
        }

        public async Task RemoveParticipant()
        {
            _context.Participants.Remove(Participant);
            await _context.SaveChangesAsync();
        }
    }
}
