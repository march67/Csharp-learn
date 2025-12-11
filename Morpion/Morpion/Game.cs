using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    public class Game
    {
        List<Player> playerList = new List<Player>();
        bool Restart = false;

        public void StartGame()
        {
            Console.Write("Joueur 1, veuillez saisir votre prénom\n");
            string playerName_1 = Console.ReadLine();

            Console.Write("Joueur 1, veuillez saisir votre symbole de jeu\n");
            char playerSymbol_1 = Console.ReadLine()[0];

            Console.Write("Joueur 2, veuillez saisir votre prénom\n");
            string playerName_2 = Console.ReadLine();

            Console.Write("Joueur 2, veuillez saisir votre symbole de jeu\n");
            char playerSymbol_2 = Console.ReadLine()[0];

            playerList.Add(new Player { PlayerName = playerName_1, PlayerSymbol = playerSymbol_1 });
            playerList.Add(new Player { PlayerName = playerName_2, PlayerSymbol = playerSymbol_2 });

            Console.Clear();

            Board board = new Board(playerList);

            GameEnded();
        }

        public void GameEnded()
        {
            Console.Write("\nRejouer une nouvelle partie ? O pour oui, N pour non\n");
            Restart = Console.ReadLine()[0] == 'O' ? true : false;
            if (Restart)
            {
                Console.Clear();
                StartGame();
            }
        }
    }
}
