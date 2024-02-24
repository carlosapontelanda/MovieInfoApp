namespace MovieInfo.api.Data;
public interface IMovieRepository
{
    Task<ICollection<Movie>> GetAllAsync(string title);
    Task<Movie> GetByIdAsync(int id);
    Task<bool> Exists(string title);
    Task<Movie> CreateAsync(Movie movie);
 }