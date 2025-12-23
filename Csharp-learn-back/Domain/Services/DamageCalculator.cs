using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services;

public class DamageCalculator
{
    private readonly (Player, Player) _players;

    public DamageCalculator((Player, Player) players)
    {
        _players = players;
    }

    public int DamageInput()
    {
        throw new NotImplementedException();
    }

    public bool IsCriticalHit()
    {
        throw new NotImplementedException();
    }

    public int CriticalHitModifier()
    {
        throw new NotImplementedException();
    }

    public int DamageMitigation()
    {
        throw new NotImplementedException();
    }

    public bool IsDodged()
    {
        throw new NotImplementedException();
    }
}