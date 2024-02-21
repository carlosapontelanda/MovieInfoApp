using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;

namespace MovieInfo.api;

[Route("api/[controller]")]
[ApiController]

//Changed to use primary constructor
public class MoviesController(IMovieRepository movieRepo) : ControllerBase
{
    private readonly IMovieRepository movieRepo = movieRepo;

    [HttpGet]
    public async Task<IActionResult> GetMovies(string? title)
    {
        var movies = await movieRepo.GetAllAsync(title);

        return (movies is null) ? NotFound()
            : Ok(movies.Select(m => m.ToMovieDto()));
    }

    [HttpGet]
    [Route("GetMovieById/{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        var movie = await movieRepo.GetByIdAsync(id);
        if (movie is null)
        {
            return NotFound();
        }
        return Ok(movie.ToMovieDto());
    }
}
