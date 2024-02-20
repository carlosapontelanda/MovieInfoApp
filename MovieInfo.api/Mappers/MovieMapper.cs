namespace MovieInfo.api;
using MovieInfo.api.DTOs;

public static class MovieMapper
{
    public static MovieDto ToMovieDto (this Movie movie)
    {
        var actorsDto = new List<ActorDto>();

        foreach (var actor in movie.Actors)
        {
            var actorDto = new ActorDto(actor.Id, actor.Name, actor.DateOfBirth, actor.Info);
            actorsDto.Add(actorDto);
        }

        var directorsDto = new List<DirectorDto>();

        foreach (var director in movie.Directors)
        {
            var directorDto = new DirectorDto(director.Id, director.Name, director.DateOfBirth, director.Info);
            directorsDto.Add(directorDto);
        }
        return new MovieDto(movie.Id, movie.Title, movie.Synopsys, movie.ReleaseDate.Year, movie.Genre.ToString(), actorsDto, directorsDto);
    }

    public static Movie ToMovieFromMovieDto(this CreateMovieDto createMovieDto)
    {

        return new Movie
        {
            Title = createMovieDto.Title,
            Synopsys = createMovieDto.Synopsys,
            ReleaseDate = createMovieDto.ReleaseYear,
            Genre = (Genre)Enum.Parse(typeof(Genre), createMovieDto.Genre)
        };
    }
}
