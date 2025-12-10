using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Board
    {
        public enum PlayerType
        {
            X,
            O
        }

        const string verticalSeparator = "|";
        const string horizontalSeparator = "------";

        public bool isFirstTurn = true;
        public PlayerType currentPlayer = PlayerType.X;

        private char[,] board;

        public Board()
        {
            board = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }

            DisplayBoard();

            ChangePlayerTurn();
        }

        private void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(board[i, 0] + verticalSeparator + board[i, 1] + verticalSeparator + board[i, 2]);

                if (i != 2)
                {
                    Console.WriteLine(horizontalSeparator);
                }
            }
        }

        public void Input(int rowInput, int columnInput, PlayerType player)
        {
            char symbol = ' ';

            if (player == PlayerType.X)
            {
                symbol = 'X';
            }
            else if(player == PlayerType.O)
            {
                symbol = 'O';
            }

            if (symbol != ' ')
            {
                board[rowInput - 1, columnInput - 1] = symbol;
            }

            DisplayBoard();

            if (CheckWinCondition() == false)
            {
                ChangePlayerTurn();
            }
        }

        private void ChangePlayerTurn()
        {
            if (currentPlayer == PlayerType.X && isFirstTurn == false)
            {
                currentPlayer = PlayerType.O;
                Console.WriteLine("Tour du joueur 2");
            }
            else
            {
                currentPlayer = PlayerType.X;
                Console.WriteLine("Tour du joueur 1");
                isFirstTurn = false;
            }

            Console.Write("Entrez la ligne : ");
            int row = int.Parse(Console.ReadLine());

            Console.Write("Entrez la colonne : ");
            int column = int.Parse(Console.ReadLine());

            Input(row, column, currentPlayer);
        }

        private bool CheckWinCondition()
        {
            for (int i = 0; i < 3 ; i++)
            {
                // Check all rows
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != ' ')
                {
                    char symbolWinner = board[i, 0];
                    Console.Write($"Le joueur : " + symbolWinner + " a gagné");
                    return true;
                }
            }

            for (int j = 0; j < 3 ; j++)
            {
                // Check all columns
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] != ' ')
                {
                    char symbolWinner = (board[0, j]);
                    Console.Write($"Le joueur : " + symbolWinner + " a gagné");
                    return true;
                }
            }

            // Check diagonal
            if ((board[0,0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0,0] != ' ')
                || (board[0, 2] == board[1, 1] && board[0, 0] == board[2, 0] && board[0, 2] != ' '))
            {
                char symbolWinner = board[1, 1];
                Console.Write($"Le joueur : " + symbolWinner + " a gagné");
                return true;
            }

            return false;
        }
    }
}
