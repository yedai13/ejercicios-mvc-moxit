﻿using Ejercicios.Unidad2.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejercicios.Unidad2.Models;

namespace Ejercicios.Unidad2.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private VidlyDBContext _context;

        public NewRentalsController(VidlyDBContext context)
        {
            _context = context; 
        }

        [HttpPost]
        public IActionResult CreateNewRentals([FromHeader]NewRentalDto newRental)
        {
            var customer = _context.Customer.Single(
                c => c.Id == newRental.CustomerId);

            var movies = _context.Movie.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rental.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
