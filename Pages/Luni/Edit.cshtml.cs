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

namespace vacanta.Pages.Luni
{
    public class EditModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public EditModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Luna Luna { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Luna == null)
            {
                return NotFound();
            }

            var luna =  await _context.Luna.FirstOrDefaultAsync(m => m.ID == id);
            if (luna == null)
            {
                return NotFound();
            }
            Luna = luna;
            ViewData["ContinentID"] = new SelectList(_context.Set<Continent>(), "ID",
"DenumireContinent");
            ViewData["TaraID"] = new SelectList(_context.Set<Tara>(), "ID",
"TaraDorita");
            ViewData["OrasID"] = new SelectList(_context.Set<Oras>(), "ID",
"NumeOras");
            ViewData["VizitatID"] = new SelectList(_context.Set<Vizitat>(), "ID",
"AmVizitat");
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

            _context.Attach(Luna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LunaExists(Luna.ID))
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

        private bool LunaExists(int id)
        {
          return _context.Luna.Any(e => e.ID == id);
        }
    }
}
