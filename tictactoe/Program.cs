using System;

namespace tictactoe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame game = new TicTacToeGame();
            game.initializeGame();
            Console.WriteLine("game winner is: " + game.startGame());

        }
    }
}
