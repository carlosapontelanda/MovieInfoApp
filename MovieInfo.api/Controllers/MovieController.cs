using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Services;

namespace MovieInfo.api;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet]
    [Route("GetAllMjovies")]
    public IActionResult GetAllMovies()
    {
        var movies = _movieService.GetAllMovies();

        return (movies is null) ? NotFound()
            : Ok(movies.Select(m => m.ToMovieDto()));
    }

    [HttpGet]
    [Route("GetMovieByTitle/{title}")]
    public IActionResult GetMovieByTitle(string title)
    {
        var movies = _movieService.GetMoviesByTitle(title);

        if (movies is null)
        {
            return NotFound();
        }
        return Ok(movies.Select(m => m.ToMovieDto()));
    }

    [HttpGet]
    [Route("GetMovieById/{id:int}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = _movieService.GetMovieById(id);
        if (movie is null)
        {
            return NotFound();
        }
        return Ok(movie.ToMovieDto());
    }
    
}
