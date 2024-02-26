using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;
using MovieInfo.api.Mappers;

namespace MovieInfo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController(IActorRepository actorRepo) : ControllerBase
    {
        private readonly IActorRepository actorRepo = actorRepo;

        [HttpGet]
        public async Task<IActionResult> GetActors(string name)
        {
            var actors = await actorRepo.GetAllAsync(name);

            return (actors is null) ? NotFound()
                : Ok(actors.Select(a => a.ToActorDto()));
        }

        [HttpGet]
        [Route("GetActorrById/{id}")]
        public async Task<IActionResult> GetActorById(int id)
        {
            var actor = await actorRepo.GetByIdAsync(id);
            if (actor is null)
            {
                return NotFound();
            }
            return Ok(actor.ToActorDto());
        }
    }
}
