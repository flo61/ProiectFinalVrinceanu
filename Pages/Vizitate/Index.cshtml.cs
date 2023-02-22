using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Vizitate
{
    public class IndexModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public IndexModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        public IList<Vizitat> Vizitat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vizitat != null)
            {
                Vizitat = await _context.Vizitat.ToListAsync();
            }
        }
    }
}
