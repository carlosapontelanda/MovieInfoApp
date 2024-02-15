namespace MovieInfo.api;
public sealed class Director
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Info { get; set; }
    public ICollection<Movie> Movies { get; set; }
}