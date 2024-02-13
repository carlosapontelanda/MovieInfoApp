namespace MovieInfo.api.Services;

public interface IMovieService
{
    public Movie GetMovieById(int id);
    public IEnumerable<Movie> GetMoviesByTitle(string movie);
    public IEnumerable<Movie> GetAllMovies();
}

