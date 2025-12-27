using System;
using System.Drawing;
using System.Windows.Forms;

namespace BasicProgrammingLab6
{
    public partial class ConnectFourGameForm : Form
    {
        private ConnectFourGameEngine gameEngine;
        private DataGridViewCellStyle player1Style;
        private DataGridViewCellStyle player2Style;
        private DataGridViewCellStyle emptyStyle;

        public ConnectFourGameForm()
        {
            InitializeComponent();
            InitializeCellStyles();
            InitializeGame();
        }

        private void InitializeCellStyles()
        {
            // Style for Player 1 (Red)
            player1Style = new DataGridViewCellStyle
            {
                BackColor = Color.Red,
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            // Style for Player 2 (Yellow)
            player2Style = new DataGridViewCellStyle
            {
                BackColor = Color.Yellow,
                ForeColor = Color.Black,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Arial", 14, FontStyle.Bold)
            };

            // Style for empty cells
            emptyStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.Gray,
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12)
            };
        }

        private void InitializeGame()
        {
            gameEngine = new ConnectFourGameEngine();
            gameEngine.GameStateChanged += GameEngine_GameStateChanged;

            InitializeDataGridView();
            UpdateGameBoard();
            UpdateStatusLabels();
        }

        private void InitializeDataGridView()
        {
            // Clear existing columns
            dataGridViewGameBoard.Columns.Clear();
            dataGridViewGameBoard.Rows.Clear();

            // Configure DataGridView
            dataGridViewGameBoard.AllowUserToAddRows = false;
            dataGridViewGameBoard.AllowUserToDeleteRows = false;
            dataGridViewGameBoard.AllowUserToResizeRows = false;
            dataGridViewGameBoard.AllowUserToResizeColumns = false;
            dataGridViewGameBoard.RowHeadersVisible = false;
            dataGridViewGameBoard.ColumnHeadersVisible = true;
            dataGridViewGameBoard.ReadOnly = true;
            dataGridViewGameBoard.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridViewGameBoard.MultiSelect = false;
            dataGridViewGameBoard.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Set column headers (column numbers)
            for (int col = 0; col < gameEngine.BoardColumns; col++)
            {
                dataGridViewGameBoard.Columns.Add($"Col{col}", (col + 1).ToString());
                dataGridViewGameBoard.Columns[col].Width = 60;
                dataGridViewGameBoard.Columns[col].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridViewGameBoard.Columns[col].HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Bold);
            }

            // Add rows
            dataGridViewGameBoard.Rows.Add(gameEngine.BoardRows);

            // Set row height
            foreach (DataGridViewRow row in dataGridViewGameBoard.Rows)
            {
                row.Height = 60;
            }
        }

        private void UpdateGameBoard()
        {
            char[,] board = gameEngine.GameBoard;

            // Reset all cells to empty style first
            foreach (DataGridViewRow row in dataGridViewGameBoard.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style = emptyStyle;
                    cell.Value = "○";  // Empty circle symbol
                }
            }

            // Update cells with player moves
            for (int row = 0; row < gameEngine.BoardRows; row++)
            {
                for (int col = 0; col < gameEngine.BoardColumns; col++)
                {
                    DataGridViewCell cell = dataGridViewGameBoard.Rows[row].Cells[col];

                    switch (board[row, col])
                    {
                        case 'X':  // Player 1
                            cell.Style = player1Style;
                            cell.Value = "X";
                            break;
                        case 'O':  // Player 2
                            cell.Style = player2Style;
                            cell.Value = "O";
                            break;
                        default:   // Empty
                            cell.Style = emptyStyle;
                            cell.Value = "○";
                            break;
                    }
                }
            }
        }

        private void UpdateStatusLabels()
        {
            // Update current player display
            labelCurrentPlayerValue.Text = gameEngine.CurrentPlayer.ToString();
            labelCurrentPlayerValue.BackColor = (gameEngine.CurrentPlayer == 'X') ? Color.Red : Color.Yellow;
            labelCurrentPlayerValue.ForeColor = (gameEngine.CurrentPlayer == 'X') ? Color.White : Color.Black;

            // Update game status
            if (gameEngine.IsGameWon)
            {
                labelGameStatus.Text = $"Player {gameEngine.CurrentPlayer} Wins!";
                labelGameStatus.BackColor = Color.Green;
                labelGameStatus.ForeColor = Color.White;
            }
            else if (gameEngine.IsGameDraw)
            {
                labelGameStatus.Text = "Game Draw!";
                labelGameStatus.BackColor = Color.Orange;
                labelGameStatus.ForeColor = Color.Black;
            }
            else
            {
                labelGameStatus.Text = "Game in Progress";
                labelGameStatus.BackColor = Color.LightBlue;
                labelGameStatus.ForeColor = Color.Black;
            }

            // Update player scores in status panel
            labelPlayer1Score.Text = $"Player X (Red)";
            labelPlayer2Score.Text = $"Player O (Yellow)";
        }

        private void GameEngine_GameStateChanged(object sender, GameStateChangedEventArgs e)
        {
            // Update UI on game state change
            UpdateGameBoard();
            UpdateStatusLabels();

            // Show message in status bar
            toolStripStatusLabel.Text = e.StatusMessage;
        }

        private void dataGridViewGameBoard_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore header clicks
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Only process clicks if game is running
            if (!gameEngine.IsGameRunning)
                return;

            // Make move in the clicked column
            bool moveSuccessful = gameEngine.MakeMove(e.ColumnIndex);

            if (!moveSuccessful)
            {
                // Show error message for invalid move
                toolStripStatusLabel.Text = $"Invalid move in column {e.ColumnIndex + 1}";
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame();
            toolStripStatusLabel.Text = "New game started! Player X's turn.";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset the current game?",
                "Reset Game",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                InitializeGame();
                toolStripStatusLabel.Text = "Game reset! Player X's turn.";
            }
        }

        private void ConnectFourGameForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Game started! Click on any column to make a move.";
        }

        private void dataGridViewGameBoard_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Highlight column when mouse hovers (only if game is running)
            if (e.ColumnIndex >= 0 && gameEngine.IsGameRunning)
            {
                for (int row = 0; row < dataGridViewGameBoard.RowCount; row++)
                {
                    DataGridViewCell cell = dataGridViewGameBoard.Rows[row].Cells[e.ColumnIndex];
                    if (cell.Style.BackColor == Color.White)  // Only highlight empty cells
                    {
                        cell.Style.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void dataGridViewGameBoard_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Remove highlight when mouse leaves
            if (e.ColumnIndex >= 0)
            {
                UpdateGameBoard();  // This will reset all cell styles
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit the game?",
                "Exit Game",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}