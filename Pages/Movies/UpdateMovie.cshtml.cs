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
    public class UpdateMovieModel : PageModel
    {
        private readonly IMovieRepository _context;
        public UpdateMovieModel(IMovieRepository _context)
        {
            this._context = _context;
        }

        [BindProperty]
        public Movie Movie{ get; set; }
        public IActionResult OnGet(int id)
        {
            Movie = _context.GetMovie(id);

            if(Movie == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }

        public IActionResult OnPost(Movie movie)
        {
            Movie = _context.UpdateMovie(movie);

            if(ModelState.IsValid)
            {
                return RedirectToPage("/Movies/Index");
            }

            return Page();
        }
    }
}
