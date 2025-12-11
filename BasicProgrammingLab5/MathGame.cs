using System;

namespace BasicProgrammingLab5
{
    /// <summary>
    /// Provides a mathematical guessing game where players attempt to guess the result of a complex calculation
    /// </summary>
    /// <remarks>
    /// This class implements an interactive math game that:
    /// - Takes two input values from the user
    /// - Performs a complex mathematical calculation involving trigonometric functions and logarithms
    /// - Challenges the player to guess the calculated result within limited attempts
    /// </remarks>
    public static class MathGame
    {
        /// <summary>
        /// Starts the mathematical guessing game
        /// </summary>
        /// <remarks>
        /// This method guides the user through the game process:
        /// 1. Collects two input values with validation
        /// 2. Performs a complex mathematical calculation
        /// 3. Provides the user with 3 attempts to guess the result
        /// 4. Provides feedback and reveals the answer if unsuccessful
        /// </remarks>
        /// <example>
        /// <code>
        /// MathGame.Start();
        /// </code>
        /// </example>
        public static void Start()
        {
            Console.Clear();
            const double pi = Math.PI;
            bool running = true;
            double a = 0;
            double b = 0;
            while (running)
            {
                a = Utility.GetDouble("Enter value a: ");
                b = Utility.GetDouble("Enter value b: ");
                if (b <= 0 || Math.Sin(Math.Pow(((pi / 2) + a), 2)) == 0)
                {
                    Console.Clear();
                    Utility.WaitKey("Error, invalid value...");
                }
                else
                    running = !running;
            }
            double result = Calculate(a, b);
            GuestResult(result);
        }
        private static double Calculate(double a, double b)// calculate result for a math guest game return result
        {
            const double pi = Math.PI;
            const double e = Math.E;
            double result = (Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4), e))) / Math.Sin(Math.Pow(((pi / 2) + a), 2));
            result = Math.Round(result, 2);
            return result;
        }
        private static void GuestResult(double result)// guest the result and match
        {
            int n;
            for (n = 3; n > 0; n -= 1)
            {
                Console.Clear();
                double userResult = Utility.GetDouble("===== Guess the Answer Game =====" + "\nTry to guess the answer: ");
                if (userResult == result)
                {
                    Console.WriteLine($"\nCongratulations, you guessed the answer ({result})");
                    Utility.WaitKey();
                    return;
                }
                else
                    Utility.WaitKey($"You have {n - 1} attempts remaining");
            }
            if (n == 0)
                Utility.WaitKey($"\nCorrect answer: {result}" + "\nPress any key to exit... ");
        }
    }
}
