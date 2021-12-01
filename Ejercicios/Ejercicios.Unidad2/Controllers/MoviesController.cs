using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Unidad2.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDBContext _context;

        public MoviesController(VidlyDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Movie> movies = _context.Movie.Include(m => m.Genre).ToList();
            return View(movies);
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            Movie movie = _context.Movie.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);

            if (movie != null)
                return View(movie);

            return RedirectToAction("Index");
        }
    }
}
