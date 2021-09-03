using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Data.Dtos;
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
        private IMapper _mapper;
        
        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            Movie movie = _mapper.Map<Movie>(movieDto);
            
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
                ReadMovieDto movieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movieDto);
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
        public IActionResult UpdateMovie(int id, [FromBody] UpdateMovieDto movieDto)
        {
            Movie movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
            if(movie == null)
            {
                return NotFound();
            }
            _mapper.Map(movieDto, movie);
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
