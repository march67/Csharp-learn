using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Board
    {
        const string VerticalSeparator = "|";
        const string HorizontalSeparator = "------";

        private IPlayer CurrentPlayerToPlay;
        private bool IsFirstTurnOfTheGame = true;
        private readonly List<IPlayer> playerList;

        public char[,] board;

        public Board(List<IPlayer> playerList)
        {
            this.playerList = playerList;

            board = new char[3, 3];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }

            RandomizePlayerTurn(playerList);

            DisplayBoard();

            while (!CheckWinCondition() && !CheckEndGame())
            {
                ChangePlayerTurn();
                CurrentPlayerToPlay.PlayerInput(this);
                DisplayBoard();
            }

            Console.Write($"\nLe joueur : " + CurrentPlayerToPlay.GetPlayerName() + " a gagné");
        }

        private void DisplayBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(board[i, 0] + VerticalSeparator + board[i, 1] + VerticalSeparator + board[i, 2]);

                if (i != 2)
                {
                    Console.WriteLine(HorizontalSeparator);
                }
            }
        }

        private void ChangePlayerTurn()
        {
            if (!IsFirstTurnOfTheGame)
            {
                CurrentPlayerToPlay = playerList[0] == CurrentPlayerToPlay
                    ? playerList[1]
                    : playerList[0];
            }
            else
            {
                IsFirstTurnOfTheGame = false;
            }
        }

        private bool CheckWinCondition()
        {
            return CheckRowWinCondition() || CheckColumnWinCondition() || CheckDiagonalWinCondition();
        }

        private bool CheckDiagonalWinCondition()
        {
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0, 0] != ' ')
                || (board[0, 2] == board[1, 1] && board[0, 2] == board[2, 0] && board[0, 2] != ' '))
            {
                return true;
            }

            return false;
        }

        private bool CheckColumnWinCondition()
        {
            for (int j = 0; j < 3; j++)
            {
                if (board[0, j] == board[1, j] && board[1, j] == board[2, j] && board[0, j] != ' ')
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckRowWinCondition()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != ' ')
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckEndGame()
        {
            bool boardIsFull = board.Cast<char>().All(c => c != ' '); // return un IEnumerable<char> pour pouvoir utiliser .All
            if (boardIsFull)
            {

                Console.Write($"\nFin de partie, aucun gagnant");
            }

            return boardIsFull;

        }

        private void RandomizePlayerTurn(List<IPlayer> playerList)
        {
            Random random = new Random();
            int index = random.Next(playerList.Count);
            CurrentPlayerToPlay = playerList[index];
        }

        public bool CheckValidCellForInput(int row, int column)
        {
            if (CurrentPlayerToPlay is HumanPlayer)
            {
                Console.WriteLine("\nVeuillez choisir une cellule vide");
            }
            
            return board[row, column] == ' ' ? true : false;
        }
    }
}
