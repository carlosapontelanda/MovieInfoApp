using MovieInfo.api.DTOs;
namespace MovieInfo.api;
public record CreateMovieDto(string Title, string Synopsys, DateOnly ReleaseYear, string Genre,
    ICollection<ActorDto> Actors, ICollection<DirectorDto> Directors);

