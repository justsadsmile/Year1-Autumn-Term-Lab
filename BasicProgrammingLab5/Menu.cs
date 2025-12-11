using DotNetEnv;
using System;

namespace Basic_Programming_Lab5
{
    /// <summary>
    /// Provides menu display and navigation functionality for the application
    /// </summary>
    /// <remarks>
    /// This class handles the main menu interface and author information display
    /// for the Basic Programming Lab 5 application.
    /// </remarks>
    public class Menu
    {
        /// <summary>
        /// Displays the main application menu with available options
        /// </summary>
        /// <remarks>
        /// This method presents the main navigation interface to the user,
        /// showing all available features and games in the application.
        /// The menu includes options for mathematical games, author information,
        /// array sorting, and the Connect Four game.
        /// </remarks>
        /// <example>
        /// <code>
        /// Menu.DisplayMenu();
        /// string choice = Console.ReadLine();
        /// </code>
        /// </example>
        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu =====");
            Console.WriteLine("1. Guess the Answer");
            Console.WriteLine("2. About the Author");
            Console.WriteLine("3. Array Sorting");
            Console.WriteLine("4. Connect Four Game");
            Console.WriteLine("5. Exit");
            Console.Write("\nYour choice: ");
        }

        /// <summary>
        /// Displays information about the application author
        /// </summary>
        /// <remarks>
        /// This method shows the student name and group information
        /// in a formatted console display.
        /// </remarks>
        /// <example>
        /// <code>
        /// Menu.ShowAuthor();
        /// </code>
        /// </example>
        public static void ShowAuthor()// about the author
        {
            string name = Environment.GetEnvironmentVariable("AUTHOR_NAME") ?? "add .env file";
            string group = Environment.GetEnvironmentVariable("AUTHOR_GROUP_NUMBER") ?? "add .env file";

            Console.Clear();
            Console.WriteLine("===== About the Author =====");
            Console.WriteLine($"Student name: {name}\nGroup: {group}");
            Utility.WaitKey();
        }
    }
}
