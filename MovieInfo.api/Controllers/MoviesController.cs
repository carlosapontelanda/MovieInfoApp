using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Services;

namespace MovieInfo.api;

[Route("api/[controller]")]
[ApiController]

//Changed to use primary constructor
public class MoviesController(IMovieService movieService) : ControllerBase
{
    private readonly IMovieService movieService = movieService;

    [HttpGet]
    public IActionResult GetMovies(string? title)
    {
        var movies = movieService.GetMovies(title);

        return (movies is null) ? NotFound()
            : Ok(movies.Select(m => m.ToMovieDto()));
    }

    [HttpGet]
    [Route("GetMovieById/{id}")]
    public IActionResult GetMovieById(int id)
    {
        var movie = movieService.GetMovieById(id);
        if (movie is null)
        {
            return NotFound();
        }
        return Ok(movie.ToMovieDto());
    }
}
