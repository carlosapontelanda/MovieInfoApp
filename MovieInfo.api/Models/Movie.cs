namespace MovieInfo.api.Models; 
public sealed class Movie
{
    public int Id { get; init; }
    public string Title { get; init; } 
    public string Synopsys { get; init; }
    public DateOnly ReleaseDate {get; init; }
    public Genre Genre { get; init; }
    public ICollection<Actor> Actors { get; set; }
    public ICollection<Director> Directors { get; set; }
}

