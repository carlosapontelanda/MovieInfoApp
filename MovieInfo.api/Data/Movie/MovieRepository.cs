using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Models;

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

        return (movies.Count == 0) ? null : movies;
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
        return movie is not null;
    }
    public async Task<Movie> CreateAsync(Movie movie)
    {
        var  actorsInMovie = movie.Actors;
        movie.Actors = new List<Actor>();

        foreach (var actor in actorsInMovie)
        {
            var actorEntity = await context.Actors.FirstOrDefaultAsync(a => a.Name == actor.Name);

            if (actorEntity is not null)
                movie.Actors.Add(actorEntity);
            else
                movie.Actors.Add(actor);
        }

        var directorsInMovie = movie.Directors;
        movie.Directors = new List<Director>();

        foreach (var director in directorsInMovie)
        {
            var directorEntity = await context.Directors.FirstOrDefaultAsync(d => d.Name == director.Name);

            if (directorEntity is not null)
                movie.Directors.Add(directorEntity);
            else
                movie.Directors.Add(director);
        }

        await context.Movies.AddAsync(movie);
        await context.SaveChangesAsync();
        return movie;
    }
}
