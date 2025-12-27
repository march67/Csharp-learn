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
        float damageInput = DamageInput(players.attacker);
        float damageMitigation = DamageMitigationPercentage(players.defender);
        float damageBeforeCheckCritical = MathF.Round(damageInput * damageMitigation, MidpointRounding.AwayFromZero);
        
        float damageAfterCheckCritical = IsCriticalHit(players.attacker, damageBeforeCheckCritical);

        return (int)Math.Round(damageAfterCheckCritical, MidpointRounding.AwayFromZero);
    }

    public float DamageInput(Player attacker)
    {
        return 10;
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
        return 0.33f;
    }

    public bool IsDodged((Player attacker, Player defender) players)
    {
        throw new NotImplementedException();
    }
}