using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Continente
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
            return Page();
        }

        [BindProperty]
        public Continent Continent { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Continent.Add(Continent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
