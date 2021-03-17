using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using abc.Facade.Models;
using abc.Infra.Data;
using System.Linq;
using System.Collections.Generic;

namespace abc.proovitoo_RIK.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly EventsDbContext _context;

        public DeleteModel(EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Participant)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
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

            Event = await _context.Events.FindAsync(id);

            var participants = _context.Participants;

            var enrolledParticipants = _context.Events                                          // Enrolled into the current event participants
                .Include(x => x.Enrollments).ThenInclude(x => x.Participant)
                .First(x => x.ID == id).Enrollments.Select(x => x.Participant).ToList();

            if (Event != null)
            {
                await RemoveEventAsync();
                await RemoveParticipantsAsync(enrolledParticipants);
            }

            return RedirectToPage("../Index");
        }

        public async Task RemoveEventAsync()
        {
            _context.Events.Remove(Event);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveParticipantsAsync(List<Participant> enrolledParticipants)
        {
            foreach (var item in enrolledParticipants)
            {
                _context.Participants.Remove(item);
            }

            await _context.SaveChangesAsync();
        }
    }
}
