using Microsoft.EntityFrameworkCore;

namespace MovieInfo.api.Data;
public class ActorRepository(ApplicationDBContext context) : IActorRepository
{
    private readonly ApplicationDBContext context = context;
    public async Task<List<Actor>> GetAllAsync(string name)
    {
        var actorsQuery = context.Actors.AsQueryable();

        if (!string.IsNullOrWhiteSpace(name))
        {
            actorsQuery = actorsQuery.Where(a => EF.Functions.Like(a.Name, $"%{name}%"));
        }

        var actors = await actorsQuery.ToListAsync();

        return (actors.Count() == 0) ? null : actors;
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var actors = await context.Actors.FirstOrDefaultAsync(a => a.Id == id);

        return (actors is null) ? null : actors;
    }
}

