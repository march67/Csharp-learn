using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Morpion;
using Morpion.Infrastructure;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(context.Configuration.GetConnectionString("DefaultConnection")));
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

Game game = new Game();
await game.StartGame();

Console.ReadLine();