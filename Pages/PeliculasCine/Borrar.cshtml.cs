using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Peliculas.CRUD.EF.Data;
using Peliculas.CRUD.EF.Models;

namespace Peliculas.CRUD.EF.Pages.PeliculasCine
{
    [IgnoreAntiforgeryToken]
    public class BorrarModel : PageModel
    {
        private readonly AplDbContext _context;

        public BorrarModel(AplDbContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Film Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Films.FirstOrDefaultAsync(m => m.ID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Films.FindAsync(id);

            if (Movie != null)
            {
                _context.Films.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index",new { borrado = true });
        }
    }
}

