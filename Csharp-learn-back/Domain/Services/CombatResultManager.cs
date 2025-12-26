using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services
{
    public class CombatResultManager
    {
        public Player[] Players = new Player[2];

        public CombatResultManager((Player, Player) players)
        {
            Players[0] = players.Item1;
            Players[1] = players.Item2;
        }

        public bool IsAnyoneDead()
        {
            bool isAnyoneDead = Players.Any(p => p.Stats.Health <= 0);

            if (isAnyoneDead)
            {
                IsWinner();
            }

            return isAnyoneDead;
        }

        public void IsWinner()
        {
            Player isWinner = Players[0].Stats.Health >= Players[1].Stats.Health
                ? Players[0]
                : Players[1];
            
            Console.WriteLine($"Winner is {isWinner.Name}");
        }
    }
}