namespace MovieInfo.api.DTOs;

public record CreateMovieDto(string Title, string Synopsys, DateOnly ReleaseYear, string Genre,
    ICollection<CreateActorDto> Actors, ICollection<CreateDirectorDto> Directors);

