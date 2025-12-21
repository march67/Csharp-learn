using Microsoft.EntityFrameworkCore;

namespace Morpion.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }
}