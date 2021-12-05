using Ejercicios.Unidad2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ejercicios.Unidad2.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Ejercicios.Unidad2.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private VidlyDBContext _context;
        private IMapper _mapper;

        public MoviesController(VidlyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MovieDto> Get(string query = null)
        {
            var moviesQuery = _context.Movie
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

            return moviesQuery
                .ToList()
                .Select(_mapper.Map<Movie, MovieDto>);
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var movie = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }

        [HttpPost]
        public IActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieDto, Movie>(movieDto);
            movie.DateAdded = DateTime.Now;
            _context.Movie.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri($"{Request.Path}/{movie.Id}", UriKind.Relative), movieDto);
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                return NotFound();

            _mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();

            return Ok();
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            var movieIdDb = _context.Movie.SingleOrDefault(m => m.Id == id);

            if (movieIdDb == null)
                return NotFound();

            _context.Movie.Remove(movieIdDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
