using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public interface IDirectorRepository
{
    Task<ICollection<Director>> GetAllAsync(string name);
    Task<Director> GetByIdAsync(int id);
    Task<Director> CreateAsync(Director director);
    Task<Director> UpdateAsync(Director director);
	Task<Director> DeleteAsync(int id);
}

