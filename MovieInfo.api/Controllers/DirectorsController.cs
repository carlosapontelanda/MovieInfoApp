using Microsoft.AspNetCore.Mvc;
using MovieInfo.api.Data;

namespace MovieInfo.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController(IDirectorRepository directorRepo) : ControllerBase
    {
        private readonly IDirectorRepository directorRepo = directorRepo;

        [HttpGet]
        public async Task<IActionResult> GetDirectors(string name)
        {
            var directors = await directorRepo.GetAllAsync(name);

            return (directors is null) ? NotFound()
                : Ok(directors.Select(m => m.ToDirectorDto()));
        }

        [HttpGet]
        [Route("GetDirectorById/{id}")]
        public async Task<IActionResult> GetDirectorById(int id)
        {
            var director = await directorRepo.GetByIdAsync(id);
            if (director is null)
            {
                return NotFound();
            }
            return Ok(director.ToDirectorDto());
        }
    }
}
