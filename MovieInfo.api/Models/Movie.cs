namespace MovieInfo.api.Models; 
public sealed class Movie
{
    public int Id { get; init; }
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    public DateOnly ReleaseDate {get; set; }
    public Genre Genre { get; set; }
    public List<Actor> Actors { get; set; } = new();
    public List<Director> Directors { get; set; } = new();
}

