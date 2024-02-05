using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieInfo.api;

[Route("api/[controller]")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public MovieController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllMovies()
    {
    var movies = _context.Movies
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            //.Include(m => m.MovieActors)
            //.ThenInclude(ma => ma.Actor.Name, )
            .ToList();
            
        if (movies.Any())
        {
            return Ok(movies);
        }
        return NotFound();   
    }

    [HttpGet("{title}")]
    public IActionResult GetMovieByTitle([FromRoute] string title)
    {
        var movie = _context.Movies.Where(m => m.Title == title);

        if (movie == null)
            return NotFound();

        return Ok(movie);
    }
}
