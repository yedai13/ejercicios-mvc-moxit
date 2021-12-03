using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;
using Ejercicios.Unidad2.ViewModels;
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

        public IActionResult New()
        {
            var genre = _context.Genre.ToList();
            MovieFormViewModel viewModel = new MovieFormViewModel()
            {
                Genre = genre
            };

            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genre = _context.Genre.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movie.Add(movie);
            }
            else
            {
                var movieIdDb = _context.Movie.First(m => m.Id == movie.Id);

                movieIdDb.Name = movie.Name;
                movieIdDb.ReleaseDate = movie.ReleaseDate;
                movieIdDb.DateAdded = movie.DateAdded;
                movieIdDb.Genre = movie.Genre;
                movieIdDb.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("movies/details/{id}")]
        public IActionResult Details(int id)
        {
            Movie movie = _context.Movie.Include(m => m.Genre).FirstOrDefault(c => c.Id == id);

            if (movie != null)
                return View(movie);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Movie movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return RedirectToAction("Index", "Movies");

            var viewModel = new MovieFormViewModel(movie)
            {
                Genre = _context.Genre.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}
