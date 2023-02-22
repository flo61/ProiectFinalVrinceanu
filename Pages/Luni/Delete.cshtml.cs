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
    public class DeleteModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public DeleteModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Luna Luna { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Luna == null)
            {
                return NotFound();
            }

            var luna = await _context.Luna.FirstOrDefaultAsync(m => m.ID == id);

            if (luna == null)
            {
                return NotFound();
            }
            else 
            {
                Luna = luna;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Luna == null)
            {
                return NotFound();
            }
            var luna = await _context.Luna.FindAsync(id);

            if (luna != null)
            {
                Luna = luna;
                _context.Luna.Remove(Luna);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
