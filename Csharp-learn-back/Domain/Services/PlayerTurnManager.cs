using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class PlayerTurnManager
{
    private readonly (Player, Player) _players;
    public Player[] Players = new Player[2];
    private Player IsWinner;
    private int RoundNumber = 0;
    private int IndexRoundNumber;
    private readonly CombatResultManager _combatResultManager;

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

    public Player Turn()
    {
        /*if (!_combatResultManager.IsAnyoneDead())
        {*/
            RoundNumber++;
            IndexRoundNumber = RoundNumber - 1; // array starts at 0
            Console.WriteLine($"Round {RoundNumber}");
            Player playerTurn = Players[IndexRoundNumber % 2];
            return playerTurn;
        /*}

        return _combatResultManager.IsWinner();*/
    }
}