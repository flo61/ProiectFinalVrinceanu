using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Luni
{
    public class IndexModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public IndexModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        public IList<Luna> Luna { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Luna != null)
            {
                Luna = await _context.Luna
                    .Include(b => b.Continent)
                    .Include(b => b.Tara)
                    .Include(b => b.Oras)
                    .Include(b => b.Vizitat)
                    .ToListAsync();
            }
        }
    }
}
