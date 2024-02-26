namespace MovieInfo.api.Data;
using MovieInfo.api.Models;
public interface IActorRepository
{
    Task<ICollection<Actor>> GetAllAsync(string name);
    Task<Actor> GetByIdAsync(int id);
}

