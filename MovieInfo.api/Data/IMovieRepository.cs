namespace MovieInfo.api.Data;
public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync(string title);
    Task<Movie> GetByIdAsync(int Id);
}