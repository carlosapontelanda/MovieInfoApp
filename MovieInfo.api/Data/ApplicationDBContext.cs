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

        /*
        modelBuilder.Entity<MovieActor>()
            .HasKey(ma => new { ma.MovieId, ma.ActorId });
        
        modelBuilder.Entity<ActorMovie>()
            .HasOne(m => m.Actor)
            .WithMany(am => am.ActorsMovies)
            .HasForeignKey(m => m.ActorId);
        modelBuilder.Entity<ActorMovie>()
            .HasOne(m => m.Movie)
            .WithMany(am => am.ActorsMovies)
            .HasForeignKey(m => m.MovieId);

        modelBuilder.Entity<DirectorMovie>()
            .HasKey(d => new { d.DirectorId, d.MovieId});

        modelBuilder.Entity<DirectorMovie>()
            .HasOne(d => d.Director)
            .WithMany(dm => dm.DirectorsMovies)
            .HasForeignKey(d => d.DirectorId);
        modelBuilder.Entity<DirectorMovie>()
            .HasOne(m => m.Movie)
            .WithMany(dm => dm.DirectorsMovies)
            .HasForeignKey(m => m.MovieId);
        */
    }
    
}