using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Luni
{
    public class CreateModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public CreateModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
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

        [BindProperty]
        public Luna Luna { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Luna.Add(Luna);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
