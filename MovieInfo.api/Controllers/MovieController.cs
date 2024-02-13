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

    //[HttpGet]
    //public IActionResult GetAllMovies()
    //{
    //var movies = _context.Movies
    //        .Include(a => a.Actors)
    //        .Include(d => d.Directors)
    //        .Include(m => m.MovieActors)
    //        .ThenInclude(ma => ma.Actor.Name, )
    //        .ToList();

    //    if (movies.Any())
    //    {
    //        return Ok(movies);
    //    }
    //    return NotFound();   
    //}

    [HttpGet]
    [Route("{title}")]
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
    [Route("{id:int}")]
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
