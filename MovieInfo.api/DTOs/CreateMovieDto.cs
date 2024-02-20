namespace MovieInfo.api;

public record CreateMovieDto(string Title, string Synopsys, DateOnly ReleaseYear, string Genre);

