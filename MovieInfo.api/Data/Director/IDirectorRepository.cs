namespace MovieInfo.api.Data;
using MovieInfo.api.Models;

public interface IDirectorRepository
{
    Task<ICollection<Director>> GetAllAsync(string name);
    Task<Director> GetByIdAsync(int id);
}

