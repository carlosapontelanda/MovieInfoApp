using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movie>()
            .HasMany(a => a.Actors)
            .WithMany(m => m.Movies)
            .UsingEntity(am => am.ToTable("MovieActors"));

        modelBuilder.Entity<Movie>()
            .HasMany(d => d.Directors)
            .WithMany(m=> m.Movies)
            .UsingEntity(md => md.ToTable("MovieDirectors"));
    }    
}