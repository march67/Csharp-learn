namespace CsharpLearn.Domain.Components;

public class Stats
{
    public int Intelligence { get; set; }
    public int Spirit { get; set; }
    public int Force { get; set; }
    public int Constitution { get; set; }
    public int Dexterity { get; set; }
    public int Agility { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }
    public int Health { get; set; }

    private Stats() { }

    public Stats(
        int health = 20,
        int intelligence = 5,
        int spirit = 5,
        int force = 5,
        int constitution = 5,
        int dexterity = 5,
        int agility = 25,
        int speed = 5,
        int luck = 30
    )
    {
        Health = health;
        Intelligence = intelligence;
        Spirit = spirit;
        Force = force;
        Constitution = constitution;
        Dexterity = dexterity;
        Agility = agility;
        Speed = speed;
        Luck = luck;
    }
    
    public static Stats Default => new();
}