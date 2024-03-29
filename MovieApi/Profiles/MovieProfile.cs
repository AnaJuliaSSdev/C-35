﻿using AutoMapper;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>(); 
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>();
    }
}
