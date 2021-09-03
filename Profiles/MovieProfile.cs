using AutoMapper;
using MovieAPI.Data.Dtos;
using MovieAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, Movie>();       
            CreateMap<Movie, ReadMovieDto>();       
            CreateMap<UpdateMovieDto, Movie>();
        }
    }
}
