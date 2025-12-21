using CsharpLearn.Domain.Entities;
using CsharpLearn.Domain.Interfaces;
using CsharpLearn.Infrastructure.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace CsharpLearn.Infrastructure.Persistence.Repositories;

public class ReadPlayerRepository : IReadPlayerRepository
{
    private readonly ApplicationDbContext _context;

    public ReadPlayerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Player?> FindByNameAsync(string name)
    {
        return await _context.Players
            .Where(player => player.Name == name)
            .FirstOrDefaultAsync();
    }
}