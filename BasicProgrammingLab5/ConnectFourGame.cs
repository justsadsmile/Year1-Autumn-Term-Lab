using System;

namespace BasicProgrammingLab5
{
    /// <summary>
    /// Represents a Connect Four game implementation
    /// </summary>
    /// <remarks>
    /// This class provides a console-based implementation of the classic Connect Four game
    /// where two players take turns dropping discs into a 6x7 grid, aiming to connect four
    /// of their discs horizontally, vertically, or diagonally.
    /// </remarks>
    public class ConnectFourGame
    {
        private const int Rows = 6;
        private const int Columns = 7;
        private const char player1 = 'X';
        private const char player2 = 'O';

        /// <summary>
        /// Starts and manages the main game loop
        /// </summary>
        /// <remarks>
        /// This method initializes the game board, manages player turns, checks for win conditions,
        /// and handles game restarts. It serves as the primary entry point for game execution.
        /// </remarks>
        /// <example>
        /// <code>
        /// ConnectFourGame.Start();
        /// </code>
        /// </example>
        public static void Start()//main game
        {
            bool playAgain = true;
            while (playAgain)
            {
                char[,] gameBoard = InitializeBoard();
                char currentPlayer = player1;
                bool gameRunning = true;
                bool playerWon = false;

                while (gameRunning)
                {
                    int playerMove = GetPlayerInput(gameBoard, currentPlayer);
                    bool isLegalMove = PlayerMove(gameBoard, playerMove, currentPlayer);
                    if (!isLegalMove)
                    {
                        Utility.WaitKey("Invalid move! Column is full. Press any key to try again...");
                        continue;
                    }
                    else if (CheckForWin(gameBoard, currentPlayer))
                    {
                        Console.Clear();
                        DisplayWinner(gameBoard, currentPlayer);
                        playerWon = true;
                        gameRunning = false;
                    }
                    else if (CheckForDraw(gameBoard))
                    {
                        Console.Clear();
                        DisplayDraw(gameBoard);
                        gameRunning = false;
                    }
                    else
                    {
                        currentPlayer = SwitchPlayer(currentPlayer);
                    }
                }
                playAgain = PlayAgain();
            }
        }
        private static char SwitchPlayer(char currentPlayer)// switch between player
        {
            if (currentPlayer == player1)
                return player2;
            else
                return player1;
        }
        private static void DisplayDraw(char[,] gameBoard)// write if game result are draw
        {
            Console.WriteLine("===== Result =====");
            DisplayBoard(gameBoard);
            Console.WriteLine("\nIt's a draw!");
        }
        private static void DisplayWinner(char[,] gameBoard, char currentPlayer)// write if we have a winner
        {
            Console.WriteLine("===== Result =====");
            DisplayBoard(gameBoard);
            Console.WriteLine($"\nPlayer {currentPlayer} wins!");
        }
        private static char[,] InitializeBoard()// create board for a game
        {
            char[,] gameBoard = new char[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    gameBoard[row, col] = '.';
                }
            }
            return gameBoard;
        }
        private static void DisplayBoard(char[,] gameBoard)// show game board on console
        {
            Console.WriteLine("\n  1 2 3 4 5 6 7");
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                Console.Write("| ");
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    Console.Write(gameBoard[row, col] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+---------------+");
        }
        private static int GetPlayerInput(char[,] gameBoard, char currentPlayer)// get input from console
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Game =====");
                DisplayBoard(gameBoard);
                Console.Write("\n Player {0}, enter column (1-7): ", currentPlayer);

                string input = Console.ReadLine();

                if (int.TryParse(input, out int inputColumn) && inputColumn >= 1 && inputColumn <= 7)
                {
                    return inputColumn - 1;
                }
                else
                {
                    Utility.WaitKey("Error, invalid value...");
                }
            }
        }
        private static bool PlayerMove(char[,] gameBoard, int column, char currentPlayer)// try make a move from player input return true if successful 
        {
            for (int i = gameBoard.GetLength(0) - 1; i >= 0; i--)
            {
                if (gameBoard[i, column] == '.')
                {
                    gameBoard[i, column] = currentPlayer;
                    return true;
                }
            }
            return false;
        }
        private static bool CheckForWin(char[,] gameBoard, char currentPlayer)// check after every move, true current player win
        {
            //Check horizontal
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col <= gameBoard.GetLength(1) - 4; col++)
                {
                    if (gameBoard[row, col] == currentPlayer &&
                        gameBoard[row, col + 1] == currentPlayer &&
                        gameBoard[row, col + 2] == currentPlayer &&
                        gameBoard[row, col + 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            //Check vertical
            for (int row = 0; row <= gameBoard.GetLength(0) - 4; row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    if (gameBoard[row, col] == currentPlayer &&
                        gameBoard[row + 1, col] == currentPlayer &&
                        gameBoard[row + 2, col] == currentPlayer &&
                        gameBoard[row + 3, col] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            //Check diagonal(top left to bottom right)
            for (int row = 0; row <= gameBoard.GetLength(0) - 4; row++)
            {
                for (int col = 0; col <= gameBoard.GetLength(1) - 4; col++)
                {
                    if (gameBoard[row, col] == currentPlayer &&
                        gameBoard[row + 1, col + 1] == currentPlayer &&
                        gameBoard[row + 2, col + 2] == currentPlayer &&
                        gameBoard[row + 3, col + 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            //Check diagonal(top right to bottom left)
            for (int row = 0; row <= gameBoard.GetLength(0) - 4; row++)
            {
                for (int col = 3; col < gameBoard.GetLength(1); col++)
                {
                    if (gameBoard[row, col] == currentPlayer &&
                        gameBoard[row + 1, col - 1] == currentPlayer &&
                        gameBoard[row + 2, col - 2] == currentPlayer &&
                        gameBoard[row + 3, col - 3] == currentPlayer)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool CheckForDraw(char[,] gameBoard)// check after every move, true if board fill
        {
            for (int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for (int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    if (gameBoard[row, col] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private static bool PlayAgain()// ask if player want to play again
        {
            while (true)
            {
                Console.WriteLine("\n===== Restart Game? =====");
                Console.Write("Play again? (y/n): ");
                string answer = Console.ReadLine().ToLower();

                if (answer == "y")
                {
                    return true;
                }
                else if (answer == "n")
                {
                    return false;
                }
                else
                {
                    Utility.WaitKey("Error, invalid value...");
                    Console.Clear();
                }
            }
        }
    }
}
