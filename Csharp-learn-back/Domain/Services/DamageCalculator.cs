using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class DamageCalculator
{
    public DamageCalculator()
    {
    }

    public int CalculateDamage((Player attacker, Player defender) players)
    {
        float damageInput = DamageInput(players.attacker);
        float damageMitigation = DamageMitigationPercentage(players.defender);
        return (int)Math.Round(damageInput * damageMitigation, MidpointRounding.AwayFromZero);
    }

    public float DamageInput(Player attacker)
    {
        return 10;
    }

    public bool IsCriticalHit(Player attacker)
    {
        throw new NotImplementedException();
    }

    public int CriticalHitModifier(Player attacker)
    {
        throw new NotImplementedException();
    }

    public float DamageMitigationPercentage(Player defender)
    {
        return 0.33f;
    }

    public bool IsDodged((Player attacker, Player defender) players)
    {
        throw new NotImplementedException();
    }
}