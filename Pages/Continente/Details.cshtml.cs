using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using vacanta.Data;
using vacanta.Models;

namespace vacanta.Pages.Continente
{
    public class DetailsModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public DetailsModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

      public Continent Continent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Continent == null)
            {
                return NotFound();
            }

            var continent = await _context.Continent.FirstOrDefaultAsync(m => m.ID == id);
            if (continent == null)
            {
                return NotFound();
            }
            else 
            {
                Continent = continent;
            }
            return Page();
        }
    }
}
