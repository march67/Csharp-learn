using CsharpLearn.Domain.Components;
using Microsoft.EntityFrameworkCore;

namespace CsharpLearn.Infrastructure;

public class ApplicationDbContext : DbContext
{
    public DbSet<Player> Players { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>().OwnsOne<Stats>(p => p.Stats);
    }
}