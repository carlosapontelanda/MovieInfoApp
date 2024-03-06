namespace MovieInfo.api.DTOs;

public record UpdateMovieDto(int Id, string Title, string Synopsys, DateOnly ReleaseYear, string Genre);

