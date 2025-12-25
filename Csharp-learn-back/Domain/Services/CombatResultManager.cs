using CsharpLearn.Domain.Entities;

namespace CsharpLearn.Domain.Services
{
    public class CombatResultManager
    {
        private PlayerTurnManager _playerTurnManager;

        public CombatResultManager(PlayerTurnManager playerTurnManager)
        {
            _playerTurnManager = playerTurnManager;
        }

        public bool IsAnyoneDead()
        {
            return _playerTurnManager.Players.Any(p => p.Stats.Health <= 0);
        }

        public Player IsWinner()
        {
            Player isWinner = _playerTurnManager.Players[0].Stats.Health >= _playerTurnManager.Players[1].Stats.Health
                ? _playerTurnManager.Players[0]
                : _playerTurnManager.Players[1];
            
            Console.WriteLine($"Winner is {isWinner.Name}");
            return isWinner;
        }
    }
}