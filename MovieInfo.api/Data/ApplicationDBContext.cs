using Microsoft.EntityFrameworkCore;

namespace MovieInfo.api;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {
         
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }

}