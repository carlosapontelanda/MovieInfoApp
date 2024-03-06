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

    public async Task<Movie> CreateAsync(Movie movie)
    {
		var existingMovie = await context.Movies
			.FirstOrDefaultAsync(m => m.Title == movie.Title && m.ReleaseDate == m.ReleaseDate);
		
		if (existingMovie is not null)
			return null;
		
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
	
	public async Task<Movie> UpdateAsync(Movie movie)
	{
		var movieToUpdate = await context.Movies.FirstOrDefaultAsync(m => m.Id == movie.Id);
		
		if (movieToUpdate is null)
			return null;
		
		movieToUpdate.Title = movie.Title;
		movieToUpdate.Synopsys = movie.Synopsys;
		movieToUpdate.ReleaseDate = movie.ReleaseDate;
		movieToUpdate.Genre = movie.Genre;
		
		await context.SaveChangesAsync();
		return movieToUpdate;
	
	}
		
	public async Task<Movie> DeleteAsync(int id)
	{
		var existingMovie = await context.Movies
			.FirstOrDefaultAsync(m => m.Id == id);
		
		if (existingMovie is null)
			return null;
		
		context.Movies.Remove(existingMovie);
		await context.SaveChangesAsync();
		return existingMovie;
	}
	
	public async Task<Movie> DeleteActorFromMovieAsync(int movieId, int actorId)
	{
		var existingMovie = await context.Movies
			.Include(a => a.Actors)
			.FirstOrDefaultAsync(m => m.Id == movieId);
		
		if (existingMovie is null)
			return null;
		
		var actorToDelete = existingMovie.Actors.FirstOrDefault(a => a.Id == actorId);
		
		if (actorToDelete is null)
			return null;
		
		existingMovie.Actors.Remove(actorToDelete);
		await context.SaveChangesAsync();
		return existingMovie;
	}
	
	public async Task<Movie> DeleteDirectorFromMovieAsync(int movieId, int directorId)
	{
		var existingMovie = await context.Movies
			.Include(d => d.Directors)
			.FirstOrDefaultAsync(m => m.Id == movieId);
		
		if (existingMovie is null)
			return null;
		
		var directorToDelete = existingMovie.Directors.FirstOrDefault(d => d.Id == directorId);
		
		if (directorToDelete is null)
			return null;
		
		existingMovie.Directors.Remove(directorToDelete);
		await context.SaveChangesAsync();
		return existingMovie;
	}
	
	public async Task<Movie> AsignActorToMovieAsync(int movieId, int actorId)
	{
		var existingMovie = await context.Movies
			.Include(a => a.Actors)
			.Include(d => d.Directors)
			.FirstOrDefaultAsync(m => m.Id == movieId);
			
		if (existingMovie is null)
			return null;
		
		var actorToAsign = context.Actors.FirstOrDefault(a => a.Id == actorId);
		
		if (actorToAsign is null)
			return null;
		
		if (!existingMovie.Actors.Any(a => a.Id == actorToAsign.Id))
			existingMovie.Actors.Add(actorToAsign);
		
		await context.SaveChangesAsync();
		return existingMovie;
    }
	
	public async Task<Movie> AsignDirectorToMovieAsync(int movieId, int directorId)
	{
		var existingMovie = await context.Movies
			.Include(a => a.Actors)
			.Include(d => d.Directors)
			.FirstOrDefaultAsync(m => m.Id == movieId);
			
		if (existingMovie is null)
			return null;
		
		var directorToAsign = context.Directors.FirstOrDefault(d => d.Id == directorId);

		if (directorToAsign is null)
			return null;
		
		if (!existingMovie.Directors.Any(d => d.Id == directorToAsign.Id))
			existingMovie.Directors.Add(directorToAsign);

		await context.SaveChangesAsync();
		return existingMovie;
    }
}

