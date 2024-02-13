namespace MovieInfo.api;

public class CreateMovieRequestDto
{
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    public DateOnly ReleaseDate {get; set; }
    public Genre Genre { get; set; }
}
