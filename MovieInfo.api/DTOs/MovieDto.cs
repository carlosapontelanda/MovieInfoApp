namespace MovieInfo.api;

public class MovieDto
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    public DateOnly ReleaseDate {get; set; }
    public string Genre { get; set; }
}
