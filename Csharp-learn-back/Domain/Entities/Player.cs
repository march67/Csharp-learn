using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsharpLearn.Domain.Components;

namespace CsharpLearn
{
    public class Player : IUnit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Stats Stats { get; set; }
        
        private Player() { }
        public Player(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
        public string GetName()
        {
            return this.Name;
        }
        public Stats GetStats()
        {
            throw new NotImplementedException();
            //return Stats;
        }
    }
}
