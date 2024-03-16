using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MovieInfo.api.Models;
using Microsoft.AspNetCore.Identity;

namespace MovieInfo.api.Data;

public class ApplicationDBContext : IdentityDbContext<AppUser>
{
	public ApplicationDBContext(DbContextOptions dbContextOptions) : base (dbContextOptions){}
	
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
		
		base.OnModelCreating(modelBuilder);
		
		var roles = new List<IdentityRole>
		{
			new IdentityRole
			{
				Name = "Admin",
				NormalizedName = "ADMIN"
			},
			new IdentityRole
			{
				Name = "User",
				NormalizedName = "USER"
			}
		};
		
		modelBuilder.Entity<IdentityRole>().HasData(roles);

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