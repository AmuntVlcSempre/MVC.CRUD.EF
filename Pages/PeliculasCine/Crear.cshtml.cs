using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Peliculas.CRUD.EF.Models;
using Peliculas.CRUD.EF.Data;

namespace Peliculas.CRUD.EF.Pages.PeliculasCine
{
    [IgnoreAntiforgeryToken]
    public class CrearModel : PageModel
    {
        private readonly AplDbContext _context;
        public CrearModel(AplDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            Movie = new Film
            {
                Genre = "Western",
                Price = 3.99M,
                ReleaseDate = DateTime.Today,
                Title = "Conan"
            };
            return Page();
        }

        [BindProperty]
        public Film Movie { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
   
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Films.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("/PeliculasCine/Index");
        }
    }

}

