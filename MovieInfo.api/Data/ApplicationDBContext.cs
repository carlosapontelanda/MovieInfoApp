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

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Movie>()
            .HasMany(a => a.Actors)
            .WithMany(m => m.Movies)
            .UsingEntity(am => am.ToTable("MovieActor"));

        modelBuilder.Entity<Movie>()
            .HasMany(d => d.Directors)
            .WithMany(m=> m.Movies)
            .UsingEntity(md => md.ToTable("MovieDirector"));
    }    
}