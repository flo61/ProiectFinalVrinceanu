using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Orase
{
    public class IndexModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public IndexModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        public IList<Oras> Oras { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Oras != null)
            {
                Oras = await _context.Oras.ToListAsync();
            }
        }
    }
}
