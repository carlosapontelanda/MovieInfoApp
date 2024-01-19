using Microsoft.EntityFrameworkCore;

namespace MovieInfo.api;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) 
    : base(dbContextOptions)
    {
         
    }

    public DbSet<Movie> Movie { get; set; }
    public DbSet<Actor> Actor { get; set; }
    public DbSet<Director> Director { get; set; }

}