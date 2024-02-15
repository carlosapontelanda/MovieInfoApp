namespace MovieInfo.api; 
public sealed class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    public DateOnly ReleaseDate {get; set; }
    public Genre Genre { get; set; }
    public List<Actor> Actors { get; set; }
    public List<Director> Directors { get; set; }
}

