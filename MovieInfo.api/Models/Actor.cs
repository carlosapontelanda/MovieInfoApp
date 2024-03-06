namespace MovieInfo.api.Models;

public sealed class Actor
{
    public int Id { get; init; }
    public string Name { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Info { get; set; }
    public ICollection<Movie> Movies { get; set; }
}
