using CsharpLearn.Domain.Interfaces;
using CsharpLearn.Domain.Entities;
using CsharpLearn.Infrastructure.Persistence.Database;

namespace CsharpLearn.Infrastructure.Persistence.Repositories;

public class WritePlayerRepository : IWritePlayerRepository
{
    private readonly ApplicationDbContext _context;

    public WritePlayerRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async void SaveAsync(Player player)
    {
        await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
    }

    public async void DeleteAsync(Player player)
    {
        throw new NotImplementedException();
    }
}