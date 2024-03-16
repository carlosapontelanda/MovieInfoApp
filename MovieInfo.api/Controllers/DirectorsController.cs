using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;
using MovieInfo.api.Mappers;
using MovieInfo.api.DTOs;
using MovieInfo.api.Controllers.ActionFilters;

namespace MovieInfo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DirectorsController(IDirectorRepository directorRepo) : ControllerBase
{
    private readonly IDirectorRepository directorRepo = directorRepo;

    [HttpGet]
    public async Task<IActionResult> Get(string name)
    {
        var directors = await directorRepo.GetAllAsync(name);

        return (directors is null) ? NotFound() : Ok(directors.Select(m => m.ToDirectorDto()));
    }

    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var director = await directorRepo.GetByIdAsync(id);
		
        if (director is null)
            return NotFound();
        
        return Ok(director.ToDirectorDto());
    }
	[HttpPost]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Create([FromBody] CreateDirectorDto createDirectorDto)
    {     
        var directorModel  = createDirectorDto.ToDirectorFromCreateDirectorDto();
		
		var newDirector = await directorRepo.CreateAsync(directorModel);

        if (newDirector is null)
            return BadRequest("This director already exists");
        
        return CreatedAtAction(nameof(GetById), new {id = newDirector.Id}, newDirector.ToDirectorDto());
	}
		
	[HttpPut]
	[ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Update([FromBody] UpdateDirectorDto updateDirectorDto)
    { 
		var directorModel = updateDirectorDto.ToDirectorFromUpdateDirectorDto();

        var updatedDirector = await directorRepo.UpdateAsync(directorModel);

        if (updatedDirector is null)
			return NotFound();
		
		return Ok(updatedDirector.ToDirectorDto());
    }
	
	[HttpDelete]
	[Route("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    { 
		var directorToDelte = await directorRepo.DeleteAsync(id);
		
		if (directorToDelte is null)
			return NotFound();
		
		return NoContent();
    }
}

