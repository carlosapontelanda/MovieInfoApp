using  Microsoft.EntityFrameworkCore;

namespace MovieInfo.api.Services;
public class MovieService(ApplicationDBContext context) : IMovieService
{
    private readonly ApplicationDBContext context = context;

    public IEnumerable<Movie> GetMovies(string? title)

    {
        var moviesQuery = context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            moviesQuery = moviesQuery.Where(m => EF.Functions.Like(m.Title, $"%{title}%"));
        }

        var movies = moviesQuery
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            .ToList();

        return (movies.Count() == 0) ? null : movies;
    }

    public Movie GetMovieById(int id)
    {
        var movie = context.Movies
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            .FirstOrDefault(x => x.Id == id);

        return movie ?? null;
    }

    public Movie CreateMovie(CreateMovieDto createMovieDto)
    {
        var movie = createMovieDto.ToMovieFromMovieDto();
        context.Movies.Add(movie);
        context.SaveChanges();

        return CreaatedAtFunction(nameof(GetMovieById), new { Id = movie.Id }, movie.ToMovieDto());
    }
}
