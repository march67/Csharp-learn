using CsharpLearn;
using CsharpLearn.Domain.Components;
using CsharpLearn.Domain.Entities;
using CsharpLearn.Domain.Interfaces;
using CsharpLearn.Domain.Services;
using CsharpLearn.Infrastructure.Persistence.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using CsharpLearn.Infrastructure.Persistence.Repositories;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        // DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));
        
        // Repositories
        services.AddScoped<IReadPlayerRepository, ReadPlayerRepository>();
        services.AddScoped<IWritePlayerRepository, WritePlayerRepository>();
    })
    .Build();

using var scope = host.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

// Test de connexion
try
{
    await dbContext.Database.OpenConnectionAsync();
    Console.WriteLine("Connexion réussie.");
    await dbContext.Database.CloseConnectionAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"Échec de connexion : {ex.Message}");
}

// Test de création de deux players
var writePlayerRepository = scope.ServiceProvider.GetRequiredService<IWritePlayerRepository>();
var readPlayerRepository = scope.ServiceProvider.GetRequiredService<IReadPlayerRepository>();

Player? player = await readPlayerRepository.FindByNameAsync("David");
if (player == null)
{
    player = new Player("David",  new Stats(speed : 15));
    await writePlayerRepository.SaveAsync(player);
}

Player? player2 = await readPlayerRepository.FindByNameAsync("Alice");
if (player2 == null)
{
    player2 = new Player("Alice", new Stats(intelligence: 15));
    await writePlayerRepository.SaveAsync(player2);
}

Player? player3 = await readPlayerRepository.FindByNameAsync("Mel");
if (player3 == null)
{
    player3 = new Player("Mel", new Stats(luck: 20));
    await writePlayerRepository.SaveAsync(player3);
}

Random random = new Random();

CombatManager combat = new CombatManager((player, player2), random);

Console.ReadLine();