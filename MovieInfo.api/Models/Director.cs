namespace MovieInfo.api;
public sealed class Director
{
    public int Id { get; init; }
    public string Name { get; init; }
    public DateOnly DateOfBirth { get; init; }
    public string Info { get; init; }
    public ICollection<Movie> Movies { get; init; }
}