using DotNetEnv;
using System;

namespace Basic_Programming_Lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            Env.Load();//load .env file

            bool stopping = false;
            while (!stopping)
            {
                Menu.DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)// 
                {
                    case "1":
                        MathGame.Start();
                        break;
                    case "2":
                        Menu.ShowAuthor();
                        break;
                    case "3":
                        Utility.CreateAndSortArrayHandle();
                        break;
                    case "4":
                        ConnectFourGame.Start();
                        break;
                    case "5":
                        stopping = Utility.CloseProg();
                        break;
                    default:
                        Utility.WaitKey("Error, press any key to try again...");
                        break;
                }
                if (stopping)
                {
                    Console.Clear();
                    Utility.WaitKey("You have exited the program, press any key to close the window...");
                }
            }
        }
    }
}
