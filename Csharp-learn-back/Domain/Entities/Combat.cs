using CsharpLearn.Domain.Services;

namespace CsharpLearn.Domain.Entities;

public class Combat
{
    public Guid Id { get; set; }
    public Player IsWinner { get; set; }
    public Player IsLoser  { get; set; }
    public DateTimeOffset OccurredAt { get; private set; }
    
    public (Player, Player) Players { get; set; }
    
    private Combat() {}

    public Combat((Player, Player) players)
    {
        Id = new Guid();
        OccurredAt = DateTimeOffset.UtcNow;
        
        // Todo real winner, real loser
        IsWinner = Players.Item1;
        IsLoser = Players.Item2;
    }
}