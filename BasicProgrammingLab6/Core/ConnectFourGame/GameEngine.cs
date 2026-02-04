using System;

namespace BasicProgrammingLab6
{
    /// <summary>
    /// Represents the Connect Four game engine
    /// </summary>
    public class ConnectFourGameEngine
    {
        private const int Rows = 6;
        private const int Columns = 7;
        private const char Player1 = 'X';
        private const char Player2 = 'O';
        private const char Empty = '.';

        private char[,] gameBoard;
        private char currentPlayer;
        private bool gameRunning;
        private bool gameWon;
        private bool gameDraw;

        /// <summary>
        /// Event triggered when game state changes
        /// </summary>
        public event EventHandler<GameStateChangedEventArgs> GameStateChanged;

        /// <summary>
        /// Initializes a new instance of the ConnectFourGameEngine class
        /// </summary>
        public ConnectFourGameEngine()
        {
            InitializeGame();
        }

        /// <summary>
        /// Gets the current game board
        /// </summary>
        public char[,] GameBoard
        {
            get { return gameBoard; }
        }

        /// <summary>
        /// Gets the current player
        /// </summary>
        public char CurrentPlayer
        {
            get { return currentPlayer; }
        }

        /// <summary>
        /// Gets whether the game is running
        /// </summary>
        public bool IsGameRunning
        {
            get { return gameRunning; }
        }

        /// <summary>
        /// Gets whether the game is won
        /// </summary>
        public bool IsGameWon
        {
            get { return gameWon; }
        }

        /// <summary>
        /// Gets whether the game is a draw
        /// </summary>
        public bool IsGameDraw
        {
            get { return gameDraw; }
        }

        /// <summary>
        /// Gets the number of rows in the game board
        /// </summary>
        public int BoardRows
        {
            get { return Rows; }
        }

        /// <summary>
        /// Gets the number of columns in the game board
        /// </summary>
        public int BoardColumns
        {
            get { return Columns; }
        }

        /// <summary>
        /// Initializes a new game
        /// </summary>
        public void InitializeGame()
        {
            gameBoard = new char[Rows, Columns];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    gameBoard[row, col] = Empty;
                }
            }

            currentPlayer = Player1;
            gameRunning = true;
            gameWon = false;
            gameDraw = false;

            OnGameStateChanged(new GameStateChangedEventArgs(
                gameBoard, currentPlayer, gameRunning, gameWon, gameDraw, "Game started! Player X's turn."));
        }

        /// <summary>
        /// Makes a move in the specified column
        /// </summary>
        /// <param name="column">Column index (0-based)</param>
        /// <returns>True if move was successful, false otherwise</returns>
        public bool MakeMove(int column)
        {
            if (!gameRunning)
                return false;

            if (column < 0 || column >= Columns)
                return false;

            int row = -1;
            for (int i = Rows - 1; i >= 0; i--)
            {
                if (gameBoard[i, column] == Empty)
                {
                    row = i;
                    break;
                }
            }

            if (row == -1)
            {
                OnGameStateChanged(new GameStateChangedEventArgs(
                    gameBoard, currentPlayer, gameRunning, gameWon, gameDraw,
                    $"Column {column + 1} is full! Choose another column."));
                return false;
            }

            gameBoard[row, column] = currentPlayer;

            if (CheckForWin(currentPlayer))
            {
                gameWon = true;
                gameRunning = false;
                OnGameStateChanged(new GameStateChangedEventArgs(
                    gameBoard, currentPlayer, gameRunning, gameWon, gameDraw,
                    $"Player {currentPlayer} wins!"));
                return true;
            }

            if (CheckForDraw())
            {
                gameDraw = true;
                gameRunning = false;
                OnGameStateChanged(new GameStateChangedEventArgs(
                    gameBoard, currentPlayer, gameRunning, gameWon, gameDraw,
                    "It's a draw!"));
                return true;
            }

            currentPlayer = (currentPlayer == Player1) ? Player2 : Player1;

            OnGameStateChanged(new GameStateChangedEventArgs(
                gameBoard, currentPlayer, gameRunning, gameWon, gameDraw,
                $"Player {currentPlayer}'s turn."));

            return true;
        }

        /// <summary>
        /// Checks if a player has won the game
        /// </summary>
        /// <param name="player">Player character to check</param>
        /// <returns>True if player has won, false otherwise</returns>
        private bool CheckForWin(char player)
        {
            // Check horizontal
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col <= Columns - 4; col++)
                {
                    if (gameBoard[row, col] == player &&
                        gameBoard[row, col + 1] == player &&
                        gameBoard[row, col + 2] == player &&
                        gameBoard[row, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check vertical
            for (int row = 0; row <= Rows - 4; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (gameBoard[row, col] == player &&
                        gameBoard[row + 1, col] == player &&
                        gameBoard[row + 2, col] == player &&
                        gameBoard[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (top-left to bottom-right)
            for (int row = 0; row <= Rows - 4; row++)
            {
                for (int col = 0; col <= Columns - 4; col++)
                {
                    if (gameBoard[row, col] == player &&
                        gameBoard[row + 1, col + 1] == player &&
                        gameBoard[row + 2, col + 2] == player &&
                        gameBoard[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            // Check diagonal (top-right to bottom-left)
            for (int row = 0; row <= Rows - 4; row++)
            {
                for (int col = 3; col < Columns; col++)
                {
                    if (gameBoard[row, col] == player &&
                        gameBoard[row + 1, col - 1] == player &&
                        gameBoard[row + 2, col - 2] == player &&
                        gameBoard[row + 3, col - 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks if the game is a draw
        /// </summary>
        /// <returns>True if game is a draw, false otherwise</returns>
        private bool CheckForDraw()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (gameBoard[row, col] == Empty)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Raises the GameStateChanged event
        /// </summary>
        /// <param name="e">Event arguments</param>
        protected virtual void OnGameStateChanged(GameStateChangedEventArgs e)
        {
            GameStateChanged?.Invoke(this, e);
        }
    }

    /// <summary>
    /// Event arguments for game state changes
    /// </summary>
    public class GameStateChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the game board
        /// </summary>
        public char[,] GameBoard { get; }

        /// <summary>
        /// Gets the current player
        /// </summary>
        public char CurrentPlayer { get; }

        /// <summary>
        /// Gets whether the game is running
        /// </summary>
        public bool IsGameRunning { get; }

        /// <summary>
        /// Gets whether the game is won
        /// </summary>
        public bool IsGameWon { get; }

        /// <summary>
        /// Gets whether the game is a draw
        /// </summary>
        public bool IsGameDraw { get; }

        /// <summary>
        /// Gets the game status message
        /// </summary>
        public string StatusMessage { get; }

        /// <summary>
        /// Initializes a new instance of GameStateChangedEventArgs
        /// </summary>
        public GameStateChangedEventArgs(char[,] gameBoard, char currentPlayer,
            bool isGameRunning, bool isGameWon, bool isGameDraw, string statusMessage)
        {
            GameBoard = gameBoard;
            CurrentPlayer = currentPlayer;
            IsGameRunning = isGameRunning;
            IsGameWon = isGameWon;
            IsGameDraw = isGameDraw;
            StatusMessage = statusMessage;
        }
    }
}