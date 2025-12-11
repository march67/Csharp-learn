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

        public void PlayerInput(Board board)
        {
            int rowInput;
            int columnInput;

            Random random = new Random();

            Console.WriteLine($"\nTour du joueur " + GetPlayerName());

            do
            {
                rowInput = random.Next(board.board.GetLength(0));
                columnInput = random.Next(board.board.GetLength(1));

            } while (!board.CheckValidCellForInput(rowInput, columnInput, this));

            Console.Write("\n");

            board.board[rowInput, columnInput] = GetPlayerSymbol();
        }
    }
}
