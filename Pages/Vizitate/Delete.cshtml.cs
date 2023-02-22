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
    public class DeleteModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public DeleteModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vizitat Vizitat { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizitat == null)
            {
                return NotFound();
            }

            var vizitat = await _context.Vizitat.FirstOrDefaultAsync(m => m.ID == id);

            if (vizitat == null)
            {
                return NotFound();
            }
            else 
            {
                Vizitat = vizitat;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vizitat == null)
            {
                return NotFound();
            }
            var vizitat = await _context.Vizitat.FindAsync(id);

            if (vizitat != null)
            {
                Vizitat = vizitat;
                _context.Vizitat.Remove(Vizitat);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
