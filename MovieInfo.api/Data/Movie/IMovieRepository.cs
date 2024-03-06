using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public interface IMovieRepository
{
    Task<ICollection<Movie>> GetAllAsync(string title);
    Task<Movie> GetByIdAsync(int id);
    Task<Movie> CreateAsync(Movie movie);
	Task<Movie> UpdateAsync(Movie movie);
	Task<Movie> DeleteAsync(int id);
	Task<Movie> DeleteActorFromMovieAsync(int movieId, int actorId);
	Task<Movie> DeleteDirectorFromMovieAsync(int movieId, int directorId);
	Task<Movie> AsignActorToMovieAsync(int movieId, int actorId);
	Task<Movie> AsignDirectorToMovieAsync(int movieId, int directorId);
 }