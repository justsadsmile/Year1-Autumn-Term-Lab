using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BasicProgrammingLab6
{
    public partial class MathGameForm : Form
    {
        private readonly GuessGame _game;

        public MathGameForm()
        {
            InitializeComponent();
            _game = new GuessGame();
            InitializeForm();
        }

        private void InitializeForm()
        {
            // Set initial values
            textBoxA.Text = "1";
            textBoxB.Text = "2";
            numericUpDownAttempts.Value = 3;
            UpdateGameStatus();
        }

        private void MathGameForm_Load(object sender, EventArgs e)
        {
            UpdateGameStatus();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate input values for a and b
                if (!InputValidator.TryParseDouble(textBoxA.Text, out double a, out string errorA))
                {
                    InputValidator.SetError(textBoxA, errorA);
                    MessageBox.Show($"Error in value a: {errorA}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!InputValidator.TryParseDouble(textBoxB.Text, out double b, out string errorB))
                {
                    InputValidator.SetError(textBoxB, errorB);
                    MessageBox.Show($"Error in value b: {errorB}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Reset errors
                InputValidator.SetError(textBoxA, string.Empty);
                InputValidator.SetError(textBoxB, string.Empty);

                // Get number of attempts
                int attempts = (int)numericUpDownAttempts.Value;

                // Initialize the game
                _game.InitializeGame(a, b, attempts);

                // Clear result and guess fields
                textBoxResult.Clear();
                textBoxGuess.Clear();
                textBoxGuess.Focus();

                // Output game start information
                textBoxResult.AppendText($"New game started!{Environment.NewLine}");
                textBoxResult.AppendText($"a = {a}, b = {b}{Environment.NewLine}");
                textBoxResult.AppendText($"Number of attempts: {attempts}{Environment.NewLine}");
                textBoxResult.AppendText($"Try to guess the function value...{Environment.NewLine}{Environment.NewLine}");

                UpdateGameStatus();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Parameter Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate guess input
                if (!InputValidator.TryParseDouble(textBoxGuess.Text, out double guess, out string error))
                {
                    InputValidator.SetError(textBoxGuess, error);
                    MessageBox.Show($"Error in guess: {error}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Reset error
                InputValidator.SetError(textBoxGuess, string.Empty);

                // Check the guess
                var result = _game.CheckGuess(guess);

                // Output the result
                textBoxResult.AppendText($"Attempt #{_game.MaxAttempts - _game.RemainingAttempts}: {guess:F4}{Environment.NewLine}");
                textBoxResult.AppendText($"Result: {result.Message}{Environment.NewLine}{Environment.NewLine}");

                // Scroll to the end
                textBoxResult.SelectionStart = textBoxResult.Text.Length;
                textBoxResult.ScrollToCaret();

                // Clear the guess input field
                textBoxGuess.Clear();
                textBoxGuess.Focus();

                UpdateGameStatus();

                // If the game is over, show a message
                if (!_game.IsGameActive)
                {
                    if (result.IsCorrect)
                    {
                        MessageBox.Show("Congratulations! You won!", "Victory",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Game over. Try again!", "Game Over",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateGameStatus()
        {
            if (_game.IsGameActive)
            {
                labelFormula.Text = $"f({_game.A:F2}, {_game.B:F2}) = ?";
                labelAttempts.Text = $"Attempts left: {_game.RemainingAttempts}";
                buttonCheck.Enabled = true;
                textBoxGuess.Enabled = true;
            }
            else
            {
                labelFormula.Text = "f(a, b) = (cos?(?) + ?(ln(b?))) / sin((?/2 + a)?)";
                labelAttempts.Text = "Number of attempts:";
                buttonCheck.Enabled = false;
                textBoxGuess.Enabled = false;
            }
        }

        private void MathGameForm_Load_1(object sender, EventArgs e)
        {

        }

        // Property to access the maximum number of attempts in the GuessGame class
        private int MaxAttempts
        {
            get { return _game.RemainingAttempts; }
        }
    }
}