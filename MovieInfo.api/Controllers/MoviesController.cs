using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;
using MovieInfo.api.Mappers;
using MovieInfo.api.DTOs;
using MovieInfo.api.Controllers.ActionFilters;

namespace MovieInfo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController(IMovieRepository movieRepo) : ControllerBase
{
    private readonly IMovieRepository movieRepo = movieRepo;

    [HttpGet]
	[Route("GetMovies")]
    public async Task<IActionResult> GetMovies(string title)
    {
        var movies = await movieRepo.GetAllAsync(title);

        return (movies is null) ? NotFound() : Ok(movies.Select(m => m.ToMovieDto()));
    }

    [HttpGet]
	[Route("GetMovieById/{Id:int}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        var movie = await movieRepo.GetByIdAsync(id);
		
        if (movie is null)
            return NotFound();
		
        return Ok(movie.ToMovieDto());
    }

    [HttpPost]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[Route("CreateMovie")]
    public async Task<IActionResult> CreateMovie([FromBody] CreateMovieDto createMovieDto)
    { 
        var movie  = createMovieDto.ToMovieFromCreateMovieDto();
		
		var existingMovie = await movieRepo.CreateAsync(movie);
		
		if (existingMovie is null)
            return BadRequest("This movie already exists");

        return CreatedAtAction(nameof(GetMovieById), new {id = movie.Id}, movie.ToMovieDto());
    }
	
	[HttpPut]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
	[Route("UpdateMovie")]
    public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieDto updateMovieDto)
    { 
        var movie  = updateMovieDto.ToMovieFromUpdateMovieDto();
		
		var existingMovie = await movieRepo.UpdateAsync(movie);
		
		 if (existingMovie is null)
             return BadRequest("This movie does not exists");

		return Ok(existingMovie.ToMovieDto());
    }
	
	[HttpDelete]
	[Route("DeleteMovie/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    { 
		var movieToDelte = await movieRepo.DeleteAsync(id);
		
		if (movieToDelte is null)
			return NotFound();
		
		return NoContent();
    }
	
	[HttpDelete]
	[Route("DeleteActorFromMovie")]
    public async Task<IActionResult> DeleteActorFromMovie(int movieId, int actorId)
    { 
		var actorToDelte = await movieRepo.DeleteActorFromMovieAsync(movieId, actorId);
		
		if (actorToDelte is null)
			return NotFound();
		
		return NoContent();
    }
	
	[HttpDelete]
	[Route("DeleteDirectorFromMovie")]
    public async Task<IActionResult> DeleteDirectorFromMovie(int movieId, int directorId)
    { 
		var directorToDelete = await movieRepo.DeleteDirectorFromMovieAsync(movieId, directorId);
		
		if (directorToDelete is null)
			return NotFound("Director or movie not found");
		
		return NoContent();
    }
	
	[HttpPut]
	[Route("AsignActorToMovie")]
    public async Task<IActionResult> AsignActorToMovie(int movieId, int actorId)
    { 	
		var asignedActor = await movieRepo.AsignActorToMovieAsync(movieId, actorId);
	
		if (asignedActor is null)
            return BadRequest("Movie or actor not found");

        return Ok(asignedActor.ToMovieDto());
    }
	
	[HttpPut]
	[Route("AsignDirectorToMovie")]
    public async Task<IActionResult> AsignDirectorToMovie(int movieId, int directorId)
    { 	
		var asignedDirector = await movieRepo.AsignDirectorToMovieAsync(movieId, directorId);
	
		if (asignedDirector is null)
            return BadRequest("Movie or director not found");

        return Ok(asignedDirector.ToMovieDto());
    }
}