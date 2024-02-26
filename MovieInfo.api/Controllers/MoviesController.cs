using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;
using MovieInfo.api.Mappers;

namespace MovieInfo.api.Controllers;

[Route("api/[controller]")]
[ApiController]

//Changed to use primary constructor
public class MoviesController(IMovieRepository movieRepo) : ControllerBase
{
    private readonly IMovieRepository movieRepo = movieRepo;

    [HttpGet]
    public async Task<IActionResult> GetMovies(string title)
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

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto createMovieDto)
    { 
        
        var movieModel  = createMovieDto.ToMovieFromCreateMovieDto();

        if (await movieRepo.Exists(movieModel.Title))
        { 
            return BadRequest("The movie already exists");
        }
        var movie = await movieRepo.CreateAsync(movieModel);

        return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie.ToMovieDto());

    }
}
