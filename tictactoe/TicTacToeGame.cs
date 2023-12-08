using System;
using System.Collections.Generic;
using System.Text;
using tictactoe.Models;

namespace tictactoe
{
    public class TicTacToeGame
    {

        Queue<Player> players;
        Board gameBoard;


        public void initializeGame()
        {

            //creating 2 Players
            var players = new List<Player>();
            PlayingPieceX crossPiece = new PlayingPieceX();
            Player player1 = new Player("Player1", crossPiece);

            PlayingPieceO noughtsPiece = new PlayingPieceO();
            Player player2 = new Player("Player2", noughtsPiece);

            players.Add(player1);
            players.Add(player2);

            //initializeBoard
            gameBoard = new Board(3);
        }

        public String startGame()
        {

            bool noWinner = true;
            while (noWinner)
            {

                //take out the player whose turn is and also put the player in the list back
                Player playerTurn = players.Dequeue();

                //get the free space from the board
                gameBoard.printBoard();
                List<KeyValuePair<int, int>> freeSpaces = gameBoard.getFreeCells();
                if (freeSpaces.Count==0)
                {
                    noWinner = false;
                    continue;
                }

                //read the user input
                Console.WriteLine("Player:" + playerTurn.name + " Enter row,column: ");
               // Scanner inputScanner = new Scanner(System.in);
                string str = Console.ReadLine();
                String[] values = str.Split(",");
                int inputRow = int.Parse(values[0]);
                int inputColumn = int.Parse(values[1]);


                //place the piece
                bool pieceAddedSuccessfully = gameBoard.addPiece(inputRow, inputColumn, playerTurn.playingPiece);
                if (!pieceAddedSuccessfully)
                {
                    //player can not insert the piece into this cell, player has to choose another cell
                    Console.WriteLine("Incorredt possition chosen, try again");
                    players.Enqueue(playerTurn);
                    continue;
                }
                players.Enqueue(playerTurn);

                bool winner = isThereWinner(inputRow, inputColumn, playerTurn.playingPiece.pieceType);
                if (winner)
                {
                    return playerTurn.name;
                }
            }

            return "tie";
        }

        public bool isThereWinner(int row, int column, PieceType pieceType)
        {

            bool rowMatch = true;
            bool columnMatch = true;
            bool diagonalMatch = true;
            bool antiDiagonalMatch = true;

            //need to check in row
            for (int i = 0; i < gameBoard.size; i++)
            {

                if (gameBoard.board[row][i] == null || gameBoard.board[row][i].pieceType != pieceType)
                {
                    rowMatch = false;
                }
            }

            //need to check in column
            for (int i = 0; i < gameBoard.size; i++)
            {

                if (gameBoard.board[i][column] == null || gameBoard.board[i][column].pieceType != pieceType)
                {
                    columnMatch = false;
                }
            }

            //need to check diagonals
            for (int i = 0, j = 0; i < gameBoard.size; i++, j++)
            {
                if (gameBoard.board[i][j] == null || gameBoard.board[i][j].pieceType != pieceType)
                {
                    diagonalMatch = false;
                }
            }

            //need to check anti-diagonals
            for (int i = 0, j = gameBoard.size - 1; i < gameBoard.size; i++, j--)
            {
                if (gameBoard.board[i][j] == null || gameBoard.board[i][j].pieceType != pieceType)
                {
                    antiDiagonalMatch = false;
                }
            }

            return rowMatch || columnMatch || diagonalMatch || antiDiagonalMatch;
        }

    }

}
