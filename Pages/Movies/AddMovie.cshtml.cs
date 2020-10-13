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
    public class AddMovieModel : PageModel
    {
        private readonly IMovieRepository _context;
        public AddMovieModel(IMovieRepository _context)
        {
            this._context = _context;
        }

        public Movie Movie { get; set; }
        public IActionResult OnPost(Movie movie)
        {
            Movie = _context.AddMovie(movie);

            return RedirectToPage("/Movies/Index");
        }
    }
}
