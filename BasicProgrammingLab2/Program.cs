using DotNetEnv;
using System;

namespace BasicProgrammingLab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Env.Load();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Guess the answer");
                Console.WriteLine("2. About the author");
                Console.WriteLine("3. Exit");

                Console.Write("\nYour choice: ");
                string choice = Console.ReadLine();

                switch (choice)// Меню
                {
                    case "1":
                        guestResult();
                        break;
                    case "2":
                        aboutTheAuthor();
                        break;
                    case "3":
                        running = closeProg();
                        break;
                    default:
                        Console.Write("Error, press any key to try again...");
                        Console.ReadKey();
                        break;
                }
                if (running == false)
                {
                    Console.Clear();
                    Console.WriteLine("You have exited the program, press any key to close the window... ");
                }
            }
        }
        static void aboutTheAuthor()
        {
            Console.Clear();
            Console.WriteLine("===== About the author =====");

            string name = Environment.GetEnvironmentVariable("AUTHOR_NAME") ?? "add .env file";
            string group = Environment.GetEnvironmentVariable("AUTHOR_GROUP_NUMBER") ?? "add .env file";

            Console.WriteLine($"Student's full name: {name}\nGroup: {group}");

            Console.Write("\nPress Enter to exit: ");
            Console.ReadLine();
        }
        static bool closeProg()
        {
            bool running = true;
            bool checking = true;
            Console.Clear();
            while (checking)
            {
                Console.Write("Confirm program exit (y/n): ");
                string confirmation = Console.ReadLine();
                if (confirmation == "y")
                {
                    checking = false;
                    running = false;
                }
                else if (confirmation == "n")
                {
                    checking = false;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error, repeated confirmation request");
                }
            }
            return running;
        }
        static void guestResult()
        {

            Console.Clear();
            double result = 0;
            bool checking = false;
            string strUserResult;
            double userResult;

            int n = 3;

            result = calculator();
            Console.Clear();
            while (n > 0)
            {
                do
                {

                    Console.Write("Try to guess the answer: ");
                    strUserResult = Console.ReadLine();
                    checking = double.TryParse(strUserResult, out userResult);
                    if (checking == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid data");
                    }
                } while (checking == false);
                if (userResult == result)
                {
                    Console.WriteLine($"Congratulations, you guessed the answer ({result})");
                    n = -1;
                }
                else
                {
                    n -= 1;
                    Console.Clear();
                    Console.WriteLine($"You didn't guess, try again, you have {n} attempts left");
                }
            }
            if (n == 0)
            {
                Console.WriteLine($"\nCorrect answer: {result}");
            }
            Console.Write("\nPress Enter to exit: ");
            Console.ReadLine();
        }
        static double calculator()
        {
            const double pi = Math.PI;
            const double e = Math.E;
            string stgA;
            string stgB;
            double a;
            double b;
            bool running = true;
            bool checking = false;
            double result;

            do
            {
                do
                {
                    Console.Write("Enter a: ");
                    stgA = Console.ReadLine();
                    checking = double.TryParse(stgA, out a);
                    if (checking == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid data");
                    }
                } while (checking == false);
                do
                {
                    Console.Write("Enter b: ");
                    stgB = Console.ReadLine();
                    checking = double.TryParse(stgB, out b);
                    if (checking == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid data");
                    }
                } while (checking == false);

                double fUp = Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4), e));
                double fDown = Math.Sin(Math.Pow(((pi / 2) + a), 2));
                result = fUp / fDown;
                running = false;
                if (Math.Pow(b, 4) < 0 || fDown == 0)
                {
                    running = true;
                    Console.Clear();
                    Console.WriteLine("Error, invalid value");
                }
            } while (running);

            result = Math.Round(result, 2);
            return result;
        }
    }
}
