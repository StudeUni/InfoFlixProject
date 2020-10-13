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
    public class DeleteMovieModel : PageModel
    {
        private readonly IMovieRepository _context;
        public DeleteMovieModel(IMovieRepository _context)
        {
            this._context = _context;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            var DeletedMovie = _context.DeleteMovie(Movie.Id);

           if(DeletedMovie == null)
            {
                return RedirectToPage("/Error");
            }

            return RedirectToPage("/Movies/Index");
        }
    }
}
