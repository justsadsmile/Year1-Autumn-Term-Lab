using System;

namespace BasicProgrammingLab6
{
    /// <summary>
    /// Class for managing the function value guessing game
    /// </summary>
    public class GuessGame
    {
        private double _correctValue;
        private int _maxAttempts;
        private int _remainingAttempts;
        private int _attemptsMade;
        private bool _isGameActive;

        public double A { get; private set; }
        public double B { get; private set; }
        public int RemainingAttempts
        {
            get { return _remainingAttempts; }
        }

        public int MaxAttempts
        {
            get { return _maxAttempts; }
        }

        public int AttemptsMade
        {
            get { return _attemptsMade; }
        }

        public bool IsGameActive
        {
            get { return _isGameActive; }
        }

        public double CorrectValue
        {
            get { return _correctValue; }
        }

        /// <summary>
        /// Initializes a new game
        /// </summary>
        public void InitializeGame(double a, double b, int maxAttempts)
        {
            if (!FunctionCalculator.ValidateParameters(a, b, out string error))
                throw new ArgumentException(error);

            A = a;
            B = b;
            _maxAttempts = maxAttempts;
            _remainingAttempts = maxAttempts;
            _attemptsMade = 0;
            _correctValue = FunctionCalculator.Calculate(a, b);
            _isGameActive = true;
        }

        /// <summary>
        /// Checks the user's guess
        /// </summary>
        public GuessResult CheckGuess(double userGuess)
        {
            if (!_isGameActive)
                return new GuessResult(false, "Game is not active. Start a new game.");

            _remainingAttempts--;
            _attemptsMade++;

            if (Math.Abs(userGuess - _correctValue) < 0.001)
            {
                _isGameActive = false;
                return new GuessResult(true, $"Congratulations! You guessed it! Correct answer: {_correctValue:F4}");
            }

            if (_remainingAttempts <= 0)
            {
                _isGameActive = false;
                return new GuessResult(false, $"No attempts left. Correct answer: {_correctValue:F4}");
            }

            string hint = userGuess < _correctValue ? "The target value is GREATER" : "The target value is LESS";
            return new GuessResult(false, $"{hint}. Attempts left: {_remainingAttempts}");
        }

        /// <summary>
        /// Resets the game
        /// </summary>
        public void Reset()
        {
            _isGameActive = false;
            _remainingAttempts = 0;
            _maxAttempts = 0;
            _attemptsMade = 0;
            _correctValue = 0;
            A = 0;
            B = 0;
        }
    }

    /// <summary>
    /// Result of checking a guess
    /// </summary>
    public class GuessResult
    {
        public bool IsCorrect { get; }
        public string Message { get; }

        public GuessResult(bool isCorrect, string message)
        {
            IsCorrect = isCorrect;
            Message = message;
        }
    }
}