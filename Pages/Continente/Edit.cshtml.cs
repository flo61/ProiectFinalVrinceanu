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

namespace vacanta.Pages.Continente
{
    public class EditModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public EditModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Continent Continent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Continent == null)
            {
                return NotFound();
            }

            var continent =  await _context.Continent.FirstOrDefaultAsync(m => m.ID == id);
            if (continent == null)
            {
                return NotFound();
            }
            Continent = continent;
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

            _context.Attach(Continent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContinentExists(Continent.ID))
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

        private bool ContinentExists(int id)
        {
          return _context.Continent.Any(e => e.ID == id);
        }
    }
}
