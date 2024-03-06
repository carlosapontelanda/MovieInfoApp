using MovieInfo.api.DTOs;
using MovieInfo.api.Models;

namespace MovieInfo.api.Mappers;

public static class MovieMapper
{
    public static MovieDto ToMovieDto (this Movie movie)
    {
        return new MovieDto
		(
			movie.Id, 
			movie.Title, 
			movie.Synopsys, 
			movie.ReleaseDate.Year, 
			movie.Genre.ToString(), 
			movie.Actors.Select(a => a.ToActorDto()).ToList(),
			movie.Directors.Select(d => d.ToDirectorDto()).ToList()
		);
    }

    public static Movie ToMovieFromCreateMovieDto(this CreateMovieDto createMovieDto)
    {
        return new Movie
        {
            Title = createMovieDto.Title,
            Synopsys = createMovieDto.Synopsys,
            ReleaseDate = createMovieDto.ReleaseYear,
            Genre = (Genre)Enum.Parse(typeof(Genre), createMovieDto.Genre),
            Actors = createMovieDto.Actors.Select(a => a.ToActorFromCreateActorDto()).ToList(),
            Directors = createMovieDto.Directors.Select(d => d.ToDirectorFromCreateDirectorDto()).ToList()
        };
    }
	
	public static Movie ToMovieFromUpdateMovieDto(this UpdateMovieDto updateMovieDto)
    {
        return new Movie
        {
			Id = updateMovieDto.Id,
            Title = updateMovieDto.Title,
            Synopsys = updateMovieDto.Synopsys,
            ReleaseDate = updateMovieDto.ReleaseYear,
            Genre = (Genre)Enum.Parse(typeof(Genre), updateMovieDto.Genre),
        };
    }
}
