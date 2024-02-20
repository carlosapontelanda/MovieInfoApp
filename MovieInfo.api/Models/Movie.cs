namespace MovieInfo.api; 
public sealed class Movie
{
    public int Id { get; init; }
    public string Title { get; init; } 
    public string Synopsys { get; init; }
    public DateOnly ReleaseDate {get; init; }
    public Genre Genre { get; init; }
    public ICollection<Actor> Actors { get; init; }
    public ICollection<Director> Directors { get; init; }
}

