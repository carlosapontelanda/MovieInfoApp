using Microsoft.EntityFrameworkCore;

namespace MovieInfo.api.Data;
public class MovieRepository(ApplicationDBContext context) : IMovieRepository
{
    private readonly ApplicationDBContext context = context;

    public async Task<ICollection<Movie>> GetAllAsync(string title)
    {
        var moviesQuery = context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
        {
            moviesQuery = moviesQuery.Where(m => EF.Functions.Like(m.Title, $"%{title}%"));
        }

        var movies = await moviesQuery
            .Include(a => a.Actors)
            .Include(d => d.Directors)
            .ToListAsync();

        return (movies.Count() == 0) ? null : movies;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        var movie = await context.Movies
        .Include(a => a.Actors)
        .Include(d => d.Directors)
        .FirstOrDefaultAsync(x => x.Id == id);

        return (movie is null) ? null : movie;
    }

    public async Task<bool> Exists(string title)
    { 
        var movie = await context.Movies.FirstOrDefaultAsync(m => m.Title == title);
        return (movie is null) ? false : true;
    }
    public async Task<Movie> CreateAsync(Movie movie)
    {
        context.Movies.Add(movie);
        await context.SaveChangesAsync();
        return movie;
    }
}
