using CsharpLearn.Domain.Components;
using CsharpLearn.Domain.Interfaces;

namespace CsharpLearn.Domain.Entities
{
    public class Player : IUnit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public int Level { get; set; } = 1;

        public int CurrentExperiencePoints { get; set; } = 0;
        public Stats Stats { get; set; }
        
        private Player() { }

        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Stats = new Stats();
        }
        public Player(string name, Stats stats)
        {
            Id = Guid.NewGuid();
            Name = name;
            Stats = stats;
        }
        public string GetName()
        {
            return this.Name;
        }
        public Stats GetStats()
        {
            return this.Stats;
        }
    }
}
