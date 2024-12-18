using Microsoft.AspNetCore.Mvc;
using Movies.Api.Contracts;
using Movies.Api.Services;

namespace Movies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = MoviesService.GetMovies();
        return Ok(result);
    }
    
    [HttpGet("{guid}")]
    public IActionResult GetByGuid(Guid guid)
    {
        var result = MoviesService.GetMovieById(guid);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody]MovieRequestDto movieDto)
    {
        var movie = MoviesService.ConvertToMovie(movieDto);
        MoviesService.AddMovie(movie);
        return Ok(movie.Id);
    }
}