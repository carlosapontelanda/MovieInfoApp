using MovieInfo.api.DTOs;

namespace MovieInfo.api;

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

    public static Movie ToMovieFromCreateMovieDto(this CreateMovieDto createMovieDto)
    {
        var actors = new List<Actor>();

        foreach (var actorDto in createMovieDto.Actors)
        { 
            var actor = new Actor() { Name = actorDto.Name, DateOfBirth = actorDto.DateOfBirth, Info = actorDto.Info };
            actors.Add(actor);
        }

        var directors = new List<Director>();

        foreach (var directorDto in createMovieDto.Directors)
        {
            var director = new Director() { Name = directorDto.Name, DateOfBirth = directorDto.DateOfBirth, Info = directorDto.Info };
            directors.Add(director);
        }
        return new Movie
        {
            Title = createMovieDto.Title,
            Synopsys = createMovieDto.Synopsys,
            ReleaseDate = createMovieDto.ReleaseYear,
            Genre = (Genre)Enum.Parse(typeof(Genre), createMovieDto.Genre),
            Actors = actors,
            Directors = directors
        };
    }
}
