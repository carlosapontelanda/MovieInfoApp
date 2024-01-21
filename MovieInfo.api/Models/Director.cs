namespace MovieInfo.api;

public class Director
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Info { get; set; }
    
    public ICollection<Movie> Movies { get; set; }
}