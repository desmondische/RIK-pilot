using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using abc.Facade.Models;
using abc.Infra.Data;

namespace abc.proovitoo_RIK.Pages.asd
{
    public class IndexModel : PageModel
    {
        private readonly abc.Infra.Data.EventsDbContext _context;

        public IndexModel(abc.Infra.Data.EventsDbContext context)
        {
            _context = context;
        }

        public IList<Participant> Participant { get;set; }

        public async Task OnGetAsync()
        {
            Participant = await _context.Participants.ToListAsync();
        }
    }
}
