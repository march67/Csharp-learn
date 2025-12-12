using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class BotPlayer : IPlayer
    {

        public char BotSymbol;

        public string BotName;

        public bool CheckPlayerName()
        {
            throw new NotImplementedException();
        }

        public bool CheckPlayerSymbol()
        {
            throw new NotImplementedException();
        }

        public string GetPlayerName()
        {
            return this.BotName;
        }

        public char GetPlayerSymbol()
        {
            return this.BotSymbol;
        }

        public (int, int, char) PlayerInput(Board boardGame)
        {
            int rowInput;
            int columnInput;

            Random random = new Random();

            Console.WriteLine($"\nTour du joueur " + GetPlayerName());

            do
            {
                rowInput = random.Next(boardGame.board.GetLength(0));
                columnInput = random.Next(boardGame.board.GetLength(1));

            } while (!boardGame.CheckValidCellForInput(rowInput, columnInput, this));

            Console.Write("\n");

            return(rowInput + 1, columnInput + 1, GetPlayerSymbol());
        }
    }
}
