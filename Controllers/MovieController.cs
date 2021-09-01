using Microsoft.AspNetCore.Mvc;
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
        private static List<Movie> movies = new List<Movie>();
        private static int id = 1;

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movie.Id = id++;
            movies.Add(movie);
            return CreatedAtAction(nameof(getMoviesForId), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult getMovies()
        {
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public IActionResult getMoviesForId(int id)
        {
            Movie movie = movies.FirstOrDefault(movie => movie.Id == id);
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
    }
}
