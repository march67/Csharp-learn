using CsharpLearn.Domain.Services;

namespace CsharpLearn.Domain.Entities;

public class Combat
{
    public Guid Id { get; set; }
    public Player IsWinner { get; set; }
    public Player IsLoser  { get; set; }
    public (Player, Player) Players { get; set; }
    
    private readonly PlayerTurnManager _playerTurnManager;
    private readonly DamageCalculator _damageCalculator;
    
    private Combat() {}

    public Combat((Player, Player) players, PlayerTurnManager playerTurnManager, DamageCalculator damageCalculator)
    {
        Players = players;
        _playerTurnManager = playerTurnManager;
        _damageCalculator = damageCalculator;
    }
}