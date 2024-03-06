using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;
using MovieInfo.api.Mappers;
using MovieInfo.api.DTOs;

namespace MovieInfo.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ActorsController(IActorRepository actorRepo) : ControllerBase
{
    private readonly IActorRepository actorRepo = actorRepo;

    [HttpGet]
    public async Task<IActionResult> Get(string name)
    {
        var actorsModel = await actorRepo.GetAllAsync(name);

        return (actorsModel is null) ? NotFound()
            : Ok(actorsModel.Select(a => a.ToActorDto()));
    }

    [HttpGet]
    [Route("GetById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var actorModel = await actorRepo.GetByIdAsync(id);
        if (actorModel is null)
        {
            return NotFound();
        }
        return Ok(actorModel.ToActorDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateActorDto createActorDto)
    { 
        
        var actorModel  = createActorDto.ToActorFromCreateActorDto();
		
		var newActor = await actorRepo.CreateAsync(actorModel);

        if (newActor is null)
            return BadRequest("This actor already exists");

        return CreatedAtAction(nameof(GetById), new {id = newActor.Id}, newActor.ToActorDto());

    }
	
	[HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateActorDto updateActorDto)
    { 
		var actorModel = updateActorDto.ToActorFromUpdateActorDto();
		
		var updatedActor = await actorRepo.UpdateAsync(actorModel);
		
		if (updatedActor is null)
			return NotFound("This actor was not found");
		
		return Ok(updatedActor.ToActorDto());
    }
	
	[HttpDelete]
	[Route("Delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    { 
		var actorToDelte = await actorRepo.DeleteAsync(id);
		
		if (actorToDelte is null)
			return NotFound("This actor was not found");
		
		return NoContent();
    }
}
    

