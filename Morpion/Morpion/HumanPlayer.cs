using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class HumanPlayer : IPlayer
    {
        public string HumanName;

        public string GetPlayerName()
        {
            return this.HumanName;
        }

        public string GetPlayerStats()
        { 
            throw new NotImplementedException();
        }
    }
}
