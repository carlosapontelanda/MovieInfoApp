namespace MovieInfo.api.Data

public interface IDirectorRepository
{
    Task<List<Director>> GetAllAsync(string? name);
    Task<Director> GetById(int Id);
}

