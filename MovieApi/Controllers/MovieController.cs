using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Controllers;

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
    [ProducesResponseType(StatusCodes.Status201Created)]
    public CreatedAtActionResult AddMovie([FromBody] CreateMovieDto movieDto)
    {
        Movie movie = _mapper.Map<Movie>(movieDto);
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById),
            new { id = movie.Id },
            movie);
    }

    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, 
        [FromQuery] int take = 10,
        [FromQuery] string? nameCinema = null)
    {
        if(nameCinema is null)
        {
            return _mapper.Map<List<ReadMovieDto>>(_context.
           Movies.Skip(skip).Take(take).ToList());
        }

        return _mapper.Map<List<ReadMovieDto>>(_context.Movies.Skip(skip).Take(take)
            .Where(movie => movie.Sessions.Any(session => session.Cinema.Name == nameCinema)).ToList());

    }

    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) { return NotFound(); }
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, 
        [FromBody] UpdateMovieDto movieDto)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if(movie == null) { return NotFound(); }
        _mapper.Map(movieDto, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMoviePatch(int id,
        JsonPatchDocument<UpdateMovieDto> patch)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) { return NotFound(); }
        
        var movieToUpdate = _mapper.Map<UpdateMovieDto>(movie);
        patch.ApplyTo(movieToUpdate, ModelState);
        
        if(!TryValidateModel(movieToUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToUpdate, movie);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies.FirstOrDefault(
            movie => movie.Id == id);
        if (movie == null) { return NotFound(); }
        _context.Remove(movie);
        _context.SaveChanges();
        return NoContent();
    }
}
