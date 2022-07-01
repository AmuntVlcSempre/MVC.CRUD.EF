using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Peliculas.CRUD.EF.Models;
using Peliculas.CRUD.EF.Data;

namespace Peliculas.CRUD.EF.Pages.Peliculas
{
    
    public class IndexModel : PageModel
    {
        private readonly AplDbContext _context;
        
        public IndexModel(AplDbContext context)
        {
            _context = context;
        }
   
        public IList<Film> Movie { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get; set; }
        #region snippet_1stSearch
        public void OnGet()
        {
            var movies = from m in _context.Films
                         select m;
            #region snippet_SearchNull
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            #endregion

            Movie = movies.ToList();
        }
        #endregion
    }
}

