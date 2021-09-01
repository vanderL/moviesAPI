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
        
        [HttpPost]
        public void AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
        }
    }
}
