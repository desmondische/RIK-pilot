using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using abc.Facade.Models;
using abc.Infra.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace abc.proovitoo_RIK.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly EventsDbContext _context;

        public DetailsModel(EventsDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Participant Participant { get; set; }
        [BindProperty]
        public Enrollment Enrollment { get; set; }
        public Event Event { get; set; }
        public SelectList Payment { get; set; } =
            new SelectList(Enum.GetValues(typeof(PaymentType)));


        public async Task<IActionResult> OnGetAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Events                       // Read enrollment data for the selected event
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

        public async Task<IActionResult> OnPostAsync(int id)
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var e = new Enrollment();                                                           // New Enrollment object
            var participants = _context.Participants;                                           // Participants Entity Context
            var enrollments = _context.Enrollments;                                             // Enrollments Entity Context

            var enrolledParticipants = _context.Events                                          // Enrolled into the current event participants
                .Include(x => x.Enrollments).ThenInclude(x => x.Participant)
                .First(x => x.ID == id).Enrollments.Select(x => x.Participant).ToList();


            if (!SpecificParticipantExists() && !enrolledParticipants.Any(s => s.PersonalCode == Participant.PersonalCode
                                                                            && s.RegisterCode == Participant.RegisterCode))     // If there is no specific (by ID Code) participant in the DB =>
            {                                                                                                                   // => Create a new one and enroll to the event
                await AddNewParticipantAsync(Participant);
                GetNewEnrollment(e, id, Participant.ID);
                await AddNewEnrollmentAsync(e);
            }

            else if (SpecificParticipantExists() && !enrolledParticipants.Any(s => s.PersonalCode == Participant.PersonalCode
                                                                                && s.RegisterCode == Participant.RegisterCode))     // If there is no specific (by ID Code) participant enrolled to the event =>
            {                                                                                                                       // => get it from the whole Participants context and enroll to the event
                var participant = participants.FirstOrDefault(s => s.PersonalCode == Participant.PersonalCode
                                                                || s.RegisterCode == Participant.RegisterCode);

                GetNewEnrollment(e, id, participant.ID);
                await AddNewEnrollmentAsync(e);
            }

            else                                                        // If duplicate is about to be created, a error page returned 
            {
                return RedirectToPage("../Error");
            }

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public bool SpecificParticipantExists()
        {
            return _context.Participants.Any(s => s.PersonalCode == Participant.PersonalCode
                                               && s.RegisterCode == Participant.RegisterCode);
        }

        public Enrollment GetNewEnrollment(Enrollment e, int id, int p)
        {
            e.EventID = id;
            e.ParticipantID = p;

            return e;
        }

        public async Task AddNewEnrollmentAsync(Enrollment e)
        {
            _context.Enrollments.Add(e);
            await _context.SaveChangesAsync();
        }

        public async Task AddNewParticipantAsync(Participant p)
        {
            _context.Participants.Add(p);
            await _context.SaveChangesAsync();
        }
    }
}
