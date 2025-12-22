namespace CsharpLearn.Domain.Entities;

public class Combat
{
    public (Player, Player) Players { get; set; }
    
    private Combat() {}

    public Combat((Player, Player) players)
    {
        Players = players;
    }
}