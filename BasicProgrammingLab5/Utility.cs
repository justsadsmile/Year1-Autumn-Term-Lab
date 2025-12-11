using System;

namespace BasicProgrammingLab5
{
    /// <summary>
    /// Provides utility methods for console input/output operations and common functionality
    /// </summary>
    /// <remarks>
    /// This static class contains helper methods for user input validation, console interaction,
    /// and menu management used throughout the application.
    /// </remarks>
    public static class Utility
    {
        /// <summary>
        /// Prompts the user to enter a double value with validation
        /// </summary>
        /// <param name="text">The prompt text to display (optional)</param>
        /// <returns>A validated double value entered by the user</returns>
        /// <remarks>
        /// This method continuously prompts the user until a valid double value is provided.
        /// It clears the console and displays error messages for invalid input.
        /// </remarks>
        /// <example>
        /// <code>
        /// double temperature = Utility.GetDouble("Enter temperature: ");
        /// </code>
        /// </example>
        public static double GetDouble(string text = "Enter value: ")
        {
            while (true)
            {
                Console.Clear();
                Console.Write(text);
                bool stop = double.TryParse(Console.ReadLine(), out double doubleNumber);
                if (stop)
                    return doubleNumber;
                else
                    WaitKey("Invalid input, please enter a number (double)...");
            }
        }

        /// <summary>
        /// Waits for user key press with optional message
        /// </summary>
        /// <param name="text">The message to display before waiting (optional)</param>
        /// <remarks>
        /// This method pauses program execution and waits for any key press.
        /// </remarks>
        /// <example>
        /// <code>
        /// Utility.WaitKey("Press any key to continue...");
        /// </code>
        /// </example>
        public static void WaitKey(string text = "Press any key to continue... ")
        {
            Console.Write("\n" + text);
            Console.ReadKey(true);
        }
        /// <summary>
        /// Confirms program exit with user
        /// </summary>
        /// <returns>true if user confirms exit; false if user cancels exit</returns>
        /// <remarks>
        /// This method presents a confirmation dialog and validates user input.
        /// It ensures the user intentionally wants to exit the application.
        /// </remarks>
        /// <example>
        /// <code>
        /// if (Utility.CloseProg())
        ///     Environment.Exit(0);
        /// </code>
        /// </example>
        public static bool CloseProg()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Exit Confirmation =====");
                Console.Write("Confirm exit from the program (y/n): ");
                string confirmation = Console.ReadLine().ToLower();
                if (confirmation == "y")
                    return true;
                else if (confirmation == "n")
                    return false;
                else
                    WaitKey("Error, requesting confirmation again...");
            }
        }

        /// <summary>
        /// Prompts the user to enter an integer value with validation
        /// </summary>
        /// <param name="text">The prompt text to display (optional)</param>
        /// <returns>A validated integer value entered by the user</returns>
        /// <remarks>
        /// This method continuously prompts the user until a valid integer value is provided.
        /// It clears the console and displays error messages for invalid input.
        /// </remarks>
        /// <example>
        /// <code>
        /// int age = Utility.GetInt("Enter your age: ");
        /// </code>
        /// </example>
        public static int GetInt(string text = "Enter value: ")
        {
            while (true)
            {
                Console.Clear();
                Console.Write(text);
                bool stop = int.TryParse(Console.ReadLine(), out int intNumber);
                if (stop)
                    return intNumber;
                else
                    WaitKey("Invalid input, please enter a number (int)...");
            }
        }

        /// <summary>
        /// Displays and manages the array processor menu
        /// </summary>
        /// <remarks>
        /// This method provides a user interface for creating and sorting arrays using
        /// the ArrayProcessor class. It allows users to choose between default array size
        /// or custom array size, and handles input validation for menu choices.
        /// </remarks>
        /// <example>
        /// <code>
        /// Utility.CreateAndSortArrayHandle();
        /// </code>
        /// </example>
        public static void CreateAndSortArrayHandle()
        {
            bool stopping = false;
            while (!stopping)
            {
                Console.Clear();
                Console.WriteLine("===== Array Processor Menu =====");
                Console.WriteLine("1. Use default constructor (10 elements)");
                Console.WriteLine("2. Use parameter constructor (custom size)");
                Console.WriteLine("3. Exit");
                Console.Write("\nYour choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        ArrayProcessor defaultProcessor = new ArrayProcessor();
                        break;
                    case "2":
                        int n = 0;
                        while (n <= 0)
                        {
                            n = GetInt("Enter array size: ");
                            if (n <= 0)
                            {
                                WaitKey("Number of elements must be greater than 0");
                            }
                        }
                        ArrayProcessor customProcessor = new ArrayProcessor(n);
                        break;
                    case "3":
                        stopping = true;
                        break;
                    default:
                        WaitKey("Error, press any key to try again...");
                        break;
                }
            }
        }
    }
}
