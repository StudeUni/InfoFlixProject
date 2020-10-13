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
    public class MovieDetailsModel : PageModel
    {
        private readonly IMovieRepository _context;

        public MovieDetailsModel(IMovieRepository _context)
        {
            this._context = _context;
        }

        public Movie Movie { get; set; }
        public IActionResult OnGet(int id)
        {
            Movie = _context.GetMovie(id);

            if(Movie == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
