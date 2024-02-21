namespace MovieInfo.api.Services;
public interface IMovieService
{
    public Movie GetMovieById(int id);
    public IEnumerable<Movie> GetMovies(string? title);
    public bool CreateMovie(Movie movie);
}

