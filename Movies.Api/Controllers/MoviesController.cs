using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Services;

namespace Movies.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : Controller
{
    [HttpGet]
    public List<Movie> GetAll()
    {
        var result = MoviesService.GetMovies();
        return result;
    }
    
    [HttpGet("{guid}")]
    public Movie GetByGuid(Guid guid)
    {
        var result = MoviesService.GetMovieById(guid);
        return result;
    }
    
    [HttpPost]
    public IActionResult Create(MovieRequestDto movieDto)
    {
        var movie = MoviesService.ConvertToMovie(movieDto);
        MoviesService.AddMovie(movie);
        return Ok(movie.Id);
    }
}