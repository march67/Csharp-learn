using CsharpLearn.Domain.Services;

namespace CsharpLearn.Domain.Entities;

public class Combat
{
    public Guid Id { get; set; }
    
    public Guid WinnerId { get; set; }
    public Guid LoserId  { get; set; }
    public Player Winner { get; set; }
    public Player Loser  { get; set; }
    public DateTimeOffset OccurredAt { get; private set; }
    
    private Combat() {}

    public Combat(Player winner, Player loser)
    {
        Id = Guid.NewGuid();
        OccurredAt = DateTimeOffset.UtcNow;

        Winner = winner;
        Loser = loser;
        WinnerId = winner.Id;
        LoserId = loser.Id;
    }
}