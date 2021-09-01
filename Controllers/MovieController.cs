using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private MovieContext _context;
        
        public MovieController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getMoviesForId), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult getMovies()
        {
            return Ok(_context.Movies);
        }

        [HttpGet("{id}")]
        public IActionResult getMoviesForId(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
            
            
            //foreach(Movie movie in movies)
            //{
            //    if(movie.Id == id)
            //    {
            //        return movie;
            //    }
            //}
            //return null;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMovie(int id, [FromBody] Movie newMovie)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            movie.Titulo = newMovie.Titulo;
            movie.Genero = newMovie.Genero;
            movie.Duracao = newMovie.Duracao;
            movie.Diretor = newMovie.Diretor;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveMovie(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NoContent();
            }
            _context.Remove(movie);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
