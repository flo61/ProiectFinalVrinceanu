using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Vizitate
{
    public class EditModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public EditModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vizitat Vizitat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vizitat == null)
            {
                return NotFound();
            }

            var vizitat =  await _context.Vizitat.FirstOrDefaultAsync(m => m.ID == id);
            if (vizitat == null)
            {
                return NotFound();
            }
            Vizitat = vizitat;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Vizitat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VizitatExists(Vizitat.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VizitatExists(int id)
        {
          return _context.Vizitat.Any(e => e.ID == id);
        }
    }
}
