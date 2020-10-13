using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoFlixProject.Models;
using InfoFlixProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InfoFlixProject.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly IMovieRepository _context;

        public IndexModel(IMovieRepository _context)
        {
            this._context = _context;
        }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IEnumerable<Movie> MovieList;
        public void OnGet(string SearchString)
        {
           MovieList = _context.SearchMovies(SearchString);
        }
    }
}
