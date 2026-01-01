using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class DamageCalculator
{
    private readonly Random _random;
    public DamageCalculator(Random random)
    {
        _random = random;
    }

    public int CalculateDamage((Player attacker, Player defender) players)
    {
        bool isDodged = IsDodged(players.attacker, players.defender);
        
        if (!isDodged)
        {
            float damageInput = DamageInput(players.attacker);
            float damageMitigation = DamageMitigationPercentage(players.defender);
            float damageBeforeCheckCritical = damageInput * damageMitigation;
            float damageAfterCheckCritical = IsCriticalHit(players.attacker, damageBeforeCheckCritical);

            return (int)Math.Round(damageAfterCheckCritical, MidpointRounding.AwayFromZero);
        }

        return 0;
    }

    public float DamageInput(Player attacker)
    {
        float damageInputMin = attacker.Stats.Force * 0.85f;
        float damageInputMax = attacker.Stats.Force * 1.05f;

        return damageInputMin + ((float)(_random.NextDouble() * (damageInputMax - damageInputMin)));
    }

    public float IsCriticalHit(Player attacker, float damageBeforeCheckCritical)
    {
        int criticalHitRate = attacker.Stats.Luck;
        bool isCriticalHit = _random.Next(100) < criticalHitRate;

        if (isCriticalHit)
        {
            Console.WriteLine($"Critical hit !");
            return damageBeforeCheckCritical * CriticalHitModifier(attacker);
        }

        return damageBeforeCheckCritical;
    }

    public float CriticalHitModifier(Player attacker)
    {
        // Luck = 10, Spirit = 20
        // Luck + Spirit = 30
        // 30 / 100 = 0.3
        // Modifier = 0.3 + 1 = 1.3
        return ((attacker.Stats.Luck + attacker.Stats.Spirit) / 100f) + 1;
    }

    public float DamageMitigationPercentage(Player defender)
    {
        return 1 - defender.Stats.Constitution / 100f;
    }

    public bool IsDodged(Player attacker, Player defender)
    {
        int percentageRateOfDodging = defender.Stats.Agility - attacker.Stats.Dexterity;
        if (percentageRateOfDodging <= 0)
        {
            return false;
        }
        
        bool isDodged = _random.Next(100) < Math.Min(percentageRateOfDodging, 33); // 33% max rate of dodging
        if (isDodged)
        {
            Console.WriteLine(defender.Name + " is dodging !");
        }
        
        return isDodged;
    }
}