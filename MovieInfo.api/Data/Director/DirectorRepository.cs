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
        var directors = await context.Directors.FirstOrDefaultAsync(d => d.Id == id );

        return (directors is null) ? null : directors;
    }
}

