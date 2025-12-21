using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Morpion.Domain.Components;

namespace Morpion
{
    public class Player : IUnit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        // private Stats Stats;
        
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
