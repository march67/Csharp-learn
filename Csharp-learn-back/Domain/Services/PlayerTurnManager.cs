using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class PlayerTurnManager
{
    private readonly (Player First, Player Second) _players;
    
    public  PlayerTurnManager((Player, Player) players)
    {
        _players = players;
    }

    public Player IsFirstTurn()
    {
        throw new NotImplementedException();
    }

    public Player NextTurn()
    {
        throw new NotImplementedException();
    }
}