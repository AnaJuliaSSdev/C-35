using AutoMapper;
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

    /// <summary>
    /// Add a movie to the database
    /// </summary>
    /// <param name="MovieDto">Object with the fields necessary to create a movie</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If insertion is successful</response>
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

    /// <summary>
    /// Retrieves a list of movies from the database with optional pagination.
    /// </summary>
    /// <remarks>
    /// This endpoint retrieves a list of movies from the database. 
    /// You can optionally specify the number of records to skip and the maximum number of records to return.
    /// </remarks>
    /// <param name="skip">Number of records to skip. Default is 0.</param>
    /// <param name="take">Maximum number of records to return. Default is 10.</param>
    /// <returns>Returns a list of movies.</returns>
    /// <response code="200">Returns the list of movies.</response>
    [HttpGet]
    public IEnumerable<ReadMovieDto> GetMovies([FromQuery] int skip = 0, 
        [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadMovieDto>>(_context.
            Movies.Skip(skip).Take(take));
    }

    /// <summary>
    /// Retrieves a movie from the database by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This endpoint retrieves a single movie from the database based on its unique identifier.
    /// </remarks>
    /// <param name="id">The unique identifier of the movie to retrieve.</param>
    /// <returns>Returns the movie with the specified identifier.</returns>
    /// <response code="200">Returns the movie with the specified identifier.</response>
    /// <response code="404">If no movie with the specified identifier is found.</response>
    [HttpGet("{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _context.Movies.FirstOrDefault(movie => movie.Id == id);
        if (movie == null) { return NotFound(); }
        var movieDto = _mapper.Map<ReadMovieDto>(movie);
        return Ok(movieDto);
    }

    /// <summary>
    /// Updates a movie in the database by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This endpoint updates an existing movie in the database based on its unique identifier.
    /// </remarks>
    /// <param name="id">The unique identifier of the movie to update.</param>
    /// <param name="movieDto">Object containing the fields to update for the movie.</param>
    /// <returns>Returns NoContent if the update is successful.</returns>
    /// <response code="204">If the update is successful.</response>
    /// <response code="404">If no movie with the specified identifier is found.</response>
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

    /// <summary>
    /// Partially updates a movie in the database by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This endpoint partially updates an existing movie in the database based on its unique identifier.
    /// </remarks>
    /// <param name="id">The unique identifier of the movie to update.</param>
    /// <param name="patch">A JSON patch document containing the fields to update for the movie.</param>
    /// <returns>Returns NoContent if the update is successful.</returns>
    /// <response code="204">If the update is successful.</response>
    /// <response code="404">If no movie with the specified identifier is found.</response>
    /// <response code="400">If the provided patch document is invalid.</response>
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

    /// <summary>
    /// Deletes a movie from the database by its unique identifier.
    /// </summary>
    /// <remarks>
    /// This endpoint deletes an existing movie from the database based on its unique identifier.
    /// </remarks>
    /// <param name="id">The unique identifier of the movie to delete.</param>
    /// <returns>Returns NoContent if the deletion is successful.</returns>
    /// <response code="204">If the deletion is successful.</response>
    /// <response code="404">If no movie with the specified identifier is found.</response>
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
