using Microsoft.EntityFrameworkCore;
using MovieInfo.api.Models;

namespace MovieInfo.api.Data;

public class ActorRepository(ApplicationDBContext context) : IActorRepository
{
    private readonly ApplicationDBContext context = context;
	
    public async Task<ICollection<Actor>> GetAllAsync(string name)
    {
        var actorsQuery = context.Actors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
            actorsQuery = actorsQuery.Where(a => EF.Functions.Like(a.Name, $"%{name}%"));

        var actors = await actorsQuery.ToListAsync();

        return (actors.Count == 0) ? null : actors;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var actor = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

        return (actor is null) ? null : actor;
    }

    public async Task<Actor> CreateAsync(Actor actor)
    {
		var existingActor = await context.Actors
			.FirstOrDefaultAsync(a => a.Name == actor.Name);
			
		if (existingActor is not null)
            return null;
		
        await context.Actors.AddAsync(actor);
        await context.SaveChangesAsync();
        return actor;
    }
	
    public async Task<Actor> UpdateAsync(Actor actor)
	{
		var existingActor = await context.Actors
			.FirstOrDefaultAsync(a => a.Id == actor.Id);
			
		if (existingActor is null)
            return null;
		
		existingActor.Name = actor.Name;
        existingActor.DateOfBirth = actor.DateOfBirth;
        existingActor.Info = actor.Info;
		
        await context.SaveChangesAsync();
        return existingActor;
	}
	
	public async Task<Actor> DeleteAsync(int id)
	{
		var existingActor = await context.Actors
			.FirstOrDefaultAsync(a => a.Id == id);
		
		if (existingActor is null)
			return null;
		
		context.Actors.Remove(existingActor);
		await context.SaveChangesAsync();
		
		return existingActor;
	}
}

