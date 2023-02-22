﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly vacanta.Data.vacantaContext _context;

        public DeleteModel(vacanta.Data.vacantaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Oras Oras { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Oras == null)
            {
                return NotFound();
            }

            var oras = await _context.Oras.FirstOrDefaultAsync(m => m.ID == id);

            if (oras == null)
            {
                return NotFound();
            }
            else 
            {
                Oras = oras;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Oras == null)
            {
                return NotFound();
            }
            var oras = await _context.Oras.FindAsync(id);

            if (oras != null)
            {
                Oras = oras;
                _context.Oras.Remove(Oras);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
