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
        var movies = _context.Movies
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            .ToList();

        return (movies.Count() == 0) ? null : movies;
    }

    public Movie GetMovieById(int id)
    {
        var movie = _context.Movies
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            .FirstOrDefault(x => x.Id == id);

        return movie ?? null;
    }

    public IEnumerable<Movie> GetMoviesByTitle(string title)
    {
        var movies = _context.Movies
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            //.Where(m => m.Title.Contains(title))
            //.Where(m => string.Equals(m.Title, title, StringComparison.InvariantCultureIgnoreCase))
            .Where(m => EF.Functions.Like(m.Title, $"%{title}%"))
            .ToList();

        return (movies.Count() == 0) ? null : movies;
    }
}
