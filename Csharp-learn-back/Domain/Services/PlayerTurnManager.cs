using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class PlayerTurnManager
{
    private readonly (Player, Player) _players;
    private Player[] Players = new Player[2];
    private int RoundNumber = 1;
    
    public  PlayerTurnManager((Player, Player) players)
    {
        if (players.Item1.Stats.Speed >= players.Item2.Stats.Speed)
        {
            Players[0] = players.Item1;
            Players[1] = players.Item2;
        }
        else
        {
            Players[0] = players.Item2;
            Players[1] = players.Item1;
        }

    }

    public Player NextTurn()
    {
        RoundNumber++;
        Console.WriteLine($"Round {RoundNumber}");
        Player playerNextTurn = Players[RoundNumber % 2 - 1];
        return playerNextTurn;
    }

    private bool IsAnyoneDead()
    {
        return Players.Any(p => p.Stats.Health <= 0);
    }
}