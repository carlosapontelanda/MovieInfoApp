namespace MovieInfo.api;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    List<Genre> Genres { get; set; } = new();
    public List<Movie> Related { get; set; } = new();
    public List<Actor> Actors { get; set; } = new();
    
}
