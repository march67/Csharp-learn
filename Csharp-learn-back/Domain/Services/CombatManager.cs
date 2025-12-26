using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class CombatManager
{
    private DamageCalculator? _damageCalculator;
    private readonly PlayerTurnManager? _playerTurnManager;
    private readonly CombatResultManager _combatResultManager;
    private (Player Attacker, Player Defender) _players;
    
    public CombatManager((Player, Player) players)
    {
        _players = players;
        _damageCalculator = new DamageCalculator();
        _combatResultManager = new CombatResultManager(_players);
        _playerTurnManager = new PlayerTurnManager(_players);


        while (!_combatResultManager.IsAnyoneDead())
        {
            ExecuteTurn();
        } 
    }

    public void ExecuteTurn()
    {
        var (attacker, defender) = GetCurrentRole();
        Console.WriteLine($"{attacker.Name} is attacking" );
        
        int damageInput = _damageCalculator.CalculateDamage((attacker, defender));

        defender.Stats.Health -= damageInput;
        Console.WriteLine($"{defender.Name} received {damageInput} damage" );
        Console.WriteLine($"{defender.Name} has {defender.Stats.Health} HP left" );
    }
    
    public (Player attacker, Player defender) GetCurrentRole()
    {
        Player attacker = _playerTurnManager.Turn();
        Player defender = attacker == _players.Attacker
            ? _players.Defender
            : _players.Attacker;

        return (attacker, defender);
    }
    
    
}