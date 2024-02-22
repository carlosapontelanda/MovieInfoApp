namespace MovieInfo.api.Data;

public interface IDirectorRepository
{
    Task<List<Director>> GetAllAsync(string name);
    Task<Director> GetByIdAsync(int id);
}

