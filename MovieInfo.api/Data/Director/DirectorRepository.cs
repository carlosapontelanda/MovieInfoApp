using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public class DirectorRepository(ApplicationDBContext context) : IDirectorRepository
{
    private readonly ApplicationDBContext context = context;

    public async Task<ICollection<Director>> GetAllAsync(string name)
    {
        var directorsQuery = context.Directors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            directorsQuery = directorsQuery.Where(d => EF.Functions.Like(d.Name, $"%{name}%"));
        }

        var directors = await directorsQuery.ToListAsync();

        return (directors.Count == 0) ? null : directors;  
    }

    public async Task<Director> GetByIdAsync(int id)
    { 
        var director = await context.Directors.FirstOrDefaultAsync(d => d.Id == id );

        return (director is null) ? null : director;
    }
	
	public async Task<Director> CreateAsync(Director director)
    {
		var existingDirector = await context.Directors
            .FirstOrDefaultAsync(d => d.Name == director.Name);
			
		if (existingDirector is not null)
            return null;
			
        await context.Directors.AddAsync(director);
        await context.SaveChangesAsync();
        return director;
    }

    public async Task<Director> UpdateAsync(Director director)
    {
        var existingDirector = await context.Directors
            .FirstOrDefaultAsync(d => d.Name == director.Name);

        if (existingDirector is null)
            return null;

        existingDirector.Name = director.Name;
        existingDirector.DateOfBirth = director.DateOfBirth;
        existingDirector.Info = director.Info;

        await context.SaveChangesAsync();
        return existingDirector;
    }
	
	public async Task<Director> DeleteAsync(int id)
	{
		var existingDirector = await context.Directors
			.FirstOrDefaultAsync(d => d.Id == id);
		
		if (existingDirector is null)
			return null;
		
		context.Directors.Remove(existingDirector);
		await context.SaveChangesAsync();
		
		return existingDirector;
	}
}

