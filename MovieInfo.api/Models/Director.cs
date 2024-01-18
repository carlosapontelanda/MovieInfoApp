namespace MovieInfo.api;

public class Director
{
    public int Id { get; set; }
    public string namespace { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Info { get; set; }
    
    public int? MovieId { get; set; }
    public Movie? Movie { get; set; }


}
