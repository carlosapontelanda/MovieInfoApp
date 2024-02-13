namespace MovieInfo.api;

public static class MovieMapper
{
    public static MovieDto ToMovieDto (this Movie movie)
    {
        return new MovieDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Synopsys = movie.Synopsys,
            ReleaseDate = movie.ReleaseDate,
            Genre = movie.Genre.ToString()
        };
    }

    public static Movie ToMovieFromCreateMovieDto(this CreateMovieRequestDto createMovieRequestDto)
    {
        return new Movie
        {
            Title = createMovieRequestDto.Title,
            Synopsys = createMovieRequestDto.Synopsys,
            ReleaseDate = createMovieRequestDto.ReleaseDate,
            Genre = createMovieRequestDto.Genre
        };
    }
}
