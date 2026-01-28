using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class CombatManager
{
    private DamageCalculator? _damageCalculator;
    private readonly PlayerTurnManager? _playerTurnManager;
    private readonly CombatResultManager _combatResultManager;
    private readonly Random _random;
    private Player Player1;
    private Player Player2;
    
    public CombatManager(Player player1, Player player2, Random random)
    {
        Player1 = player1;
        Player2 = player2;
        _damageCalculator = new DamageCalculator(random);
        _combatResultManager = new CombatResultManager((Player1, Player2));
        _playerTurnManager = new PlayerTurnManager((Player1, Player2));
    }

    public void Run()
    {
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
        Player defender = GetOpponent(attacker);

        return (attacker, defender);
    }

    public Player GetOpponent(Player player)
    {
        return player == Player1 ? Player2 : Player1;
    }
    
    
}