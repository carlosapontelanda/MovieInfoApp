using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public interface IActorRepository
{
    Task<ICollection<Actor>> GetAllAsync(string name);
    Task<Actor> GetByIdAsync(int id);
    Task<Actor> CreateAsync(Actor actor);
	Task<Actor> UpdateAsync(Actor actor); 
	Task<Actor> DeleteAsync(int Id);
}