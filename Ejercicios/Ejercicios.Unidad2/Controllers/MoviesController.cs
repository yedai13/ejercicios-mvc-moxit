using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;

namespace Ejercicios.Unidad2.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Index()
        {
            List<Movie> movies = new()
            {
                new Movie {Id = 1, Name = "Toys Story"},
                new Movie {Id = 2, Name = "Shrek!"},
                new Movie {Id = 1, Name = "Wall-e"}

            };
            return View(movies);
        }
    }
}
