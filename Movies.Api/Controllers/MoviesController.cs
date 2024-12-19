using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Contracts;
using Movies.Api.Services;

namespace Movies.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController()
    {
        _movieService = new MoviesService();
    }
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _movieService.GetMovies();
        return Ok(result);
    }
    
    [HttpGet("{id:guid}")]
    public IActionResult GetByGuid([FromRoute] Guid id)
    {
        var result = _movieService.GetMovieById(id);
        return Ok(result);
    }
    
    [HttpPost]
    public IActionResult Create([FromBody]MovieRequestDto movieDto)
    {
        var movie = _movieService.ConvertToMovie(movieDto);
        _movieService.AddMovie(movie);
        return Ok(movie.Id);
    }
}