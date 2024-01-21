namespace MovieInfo.api;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } 
    public string Synopsys { get; set; }
    List<Genre> Genres { get; set; }
    
    public ICollection<Actor> Actors { get; set; } 
    public ICollection<Director> Directors { get; set; }
}

