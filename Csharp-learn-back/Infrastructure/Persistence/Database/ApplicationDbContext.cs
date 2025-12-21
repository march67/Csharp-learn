using CsharpLearn.Domain.Components;
using CsharpLearn.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsharpLearn.Infrastructure.Persistence.Database;

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