using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Contracts;
using Movies.Api.Identity;
using Movies.Api.Services;

namespace Movies.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MoviesController()
    {
        _movieService = new MoviesService();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public IActionResult GetAll()
    {
        var result = _movieService.GetMovies();
        return Ok(result);
    }
    
    [AllowAnonymous]
    [HttpGet("{id:guid}")]
    public IActionResult GetByGuid([FromRoute] Guid id)
    {
        var result = _movieService.GetMovieById(id);
        return Ok(result);
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult Create([FromBody]MovieRequestDto movieDto)
    {
        var movie = _movieService.ConvertToMovie(movieDto);
        _movieService.AddMovie(movie);
        return Ok(movie.Id);
    }
    
    [Authorize]
    // [Authorize(Policy = IdentityData.AdminUserPolicyName)] - one way to use the policy
    [RequiresClaim(IdentityData.AdminUserClaimName, "true")] // - a little more 'pro' way to use the policy
    [HttpDelete("{id:guid}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var result = _movieService.DeleteMovie(id);
        return result 
            ? Ok() 
            : NotFound();
    }
}