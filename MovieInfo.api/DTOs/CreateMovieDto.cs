using MovieInfo.api.DTOs;
namespace MovieInfo.api;
public record CreateMovieDto(int Id, string Title, string Synopsys, DateOnly ReleaseYear, string Genre,
    ICollection<ActorDto> Actors, ICollection<DirectorDto> Directors);

