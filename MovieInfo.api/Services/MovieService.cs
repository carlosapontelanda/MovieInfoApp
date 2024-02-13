using  Microsoft.EntityFrameworkCore;

namespace MovieInfo.api.Services;
public class MovieService : IMovieService
{
    private readonly ApplicationDBContext _context;
    public MovieService(ApplicationDBContext context)
    {
        _context = context;
    }

    public IEnumerable<Movie> GetAllMovies()
    {
        throw new NotImplementedException();
    }

    public Movie GetMovieById(int id)
    {
        var movie = _context.Movies.Find(id);
        return movie ?? null;
    }

    public IEnumerable<Movie> GetMoviesByTitle(string title)
    {
        var movies = _context.Movies
            .Where(m => m.Title.Contains(title))
            .ToList();

        if (movies.Count() == 0)
        { 
            return null;
        }
        return movies;
        
    }
}
