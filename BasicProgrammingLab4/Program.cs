using DotNetEnv;
using System;
using System.Diagnostics;

namespace BasicProgrammingLab4
{
    class Program
    {
        //menu
        static void Main(string[] args)//menu program
        {
            Env.Load();

            bool stopping = false;
            while (!stopping)
            {
                DisplayMenu();
                string choice = Console.ReadLine();
                switch (choice)// 
                {
                    case "1":
                        MathGame();
                        break;
                    case "2":
                        ShowAuthor();
                        break;
                    case "3":
                        CreateAndSortArray();
                        break;
                    case "4":
                        ConnectFourGame();
                        break;
                    case "5":
                        stopping = CloseProg();
                        break;
                    default:
                        WaitKey("Error, press any key to try again...");
                        break;
                }
                if (stopping)
                {
                    Console.Clear();
                    WaitKey("You have exited the program, press any key to close the window...");
                }
            }
        }
        static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("===== Menu =====");
            Console.WriteLine("1. Guess the Answer");
            Console.WriteLine("2. About the Author");
            Console.WriteLine("3. Array Sorting");
            Console.WriteLine("4. Connect Four Game"); 
            Console.WriteLine("5. Exit");

            Console.Write("\nChoice: ");
            
        }
        //1
        static void MathGame()//math game guest the answer
        {
            Console.Clear();
            const double pi = Math.PI;
            bool running = true;
            double a = 0;
            double b = 0;
            while (running)
            {
                a = GetDouble("Enter value a: ");
                b = GetDouble("Enter value b: ");
                if (b <= 0 || Math.Sin(Math.Pow(((pi / 2) + a), 2)) == 0)//check for division by zero
                {
                    Console.Clear();
                    WaitKey("Error, invalid value...");
                }
                else
                    running = !running;
            }
            double result = Calculate(a, b);
            GuestResult(result);
        }
        static double Calculate(double a, double b)// calculate result for a math guest game return result
        {
            const double pi = Math.PI;
            const double e = Math.E;
            double result = (Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4), e))) / Math.Sin(Math.Pow(((pi / 2) + a), 2));
            result = Math.Round(result, 2);
            return result;
        }
        static void GuestResult(double result)// guest the result and match
        {
            int n;
            for (n = 3; n > 0; n -= 1)
            {
                Console.Clear();
                double userResult = GetDouble("===== Guess the Answer Game =====" + "\nTry to guess the answer: ");
                if (userResult == result)
                {
                    Console.WriteLine($"\nCongratulations, you guessed the answer ({result})"); 
                    WaitKey();
                    return;
                }
                else
                    WaitKey($"You have {n - 1} attempts remaining");
            }
            if (n == 0)
                WaitKey($"\nCorrect answer: {result}" + "\nPress any key to exit... ");
        }
        //2
        static void ShowAuthor()// about the author
        {
            string name = Environment.GetEnvironmentVariable("AUTHOR_NAME") ?? "add .env file";
            string group = Environment.GetEnvironmentVariable("AUTHOR_GROUP_NUMBER") ?? "add .env file";

            Console.Clear();
            Console.WriteLine("===== About the Author =====");
            Console.WriteLine($"Student Name: {name}\nGroup: {group}");
            WaitKey();
        }
        //3
        static void CreateAndSortArray()//creating and sorting an array
        {
            int n = AskLength();
            int[] userArray = CreateAndFillArray(n);

            int[] copyUserArrayBubble = GetCopyArray(userArray);
            double timeBubble = GetSortTime(copyUserArrayBubble, "Bubble");//+sort in this methods

            int[] copyUserArrayShell = GetCopyArray(userArray);
            double timeShell = GetSortTime(copyUserArrayShell, "Shell");//+sort in this methods

            DisplayDifference(timeBubble, timeShell);

            DisplayArray(userArray, copyUserArrayBubble, copyUserArrayShell);
        }
        static int AskLength()//ask for array length
        {
            bool stopping = true;
            int n;
            do
            {
                Console.Clear();
                Console.Write("===== Array Sorting =====");
                Console.Write("\nEnter array size: ");
                stopping = int.TryParse(Console.ReadLine(), out n);
                if (n <= 0)
                {
                    stopping = false;
                    WaitKey("Error, invalid value...");
                }
            } while (!stopping);
            return n;
        }
        static int[] CreateAndFillArray(int n)//create and fill array with class Random
        {
            Random random = new Random();
            int[] userArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                userArray[i] = random.Next(1000);
            }
            return userArray;
        }
        static int[] GetCopyArray(int[] userArray)// copy array using loop for() return
        {
            int[] copyArray = new int[userArray.Length];
            for (int i = 0; i < userArray.Length; i++)
            {
                copyArray[i] = userArray[i];
            }
            return copyArray;
        }
        static double GetSortTime(int[] array, string text)// get sort time methods and return time in ms
        {
            double time;
            Stopwatch timeToDone = new Stopwatch();
            timeToDone.Start();
            if(text == "Bubble")//add enum later
            {
                SortArrayBubble(array);
            }
            else if(text == "Shell")
            {
                SortArrayShell(array);
            }
            else
            {
                Console.WriteLine("Error no sort was done");//do throw exemption later
            }
                timeToDone.Stop();
            Console.WriteLine("\n{0} sort execution time: {1}", text, timeToDone.Elapsed);
            time = timeToDone.Elapsed.TotalMilliseconds;
            return time;
        }
        static void DisplayDifference(double timeBubble, double timeShell)// show difference between sort type
        {
            double timeDifference = timeShell - timeBubble;
            if (timeBubble <= timeShell)
                Console.WriteLine($"Bubble sort is faster than Shell sort by {timeDifference:F4} ms");
            else
                Console.WriteLine($"Shell sort is faster than Bubble sort by {Math.Abs(timeDifference):F4} ms");
        }
        static void DisplayArray(int[] userArray, int[] copyUserArrayB, int[] copyUserArrayS)// print array on console if length < 11
        {

            if (userArray.Length <= 10)
            {
                WriteArray("Original array:\n", userArray);
                WriteArray("Sorted array (Bubble):\n", copyUserArrayB);
                WriteArray("Sorted array (Shell):\n", copyUserArrayS);
                WaitKey();
            }
            else
                WaitKey("Arrays cannot be displayed because array length is greater than 10");
            
        }
        static void WriteArray(string text, int[] array)// print array
        {
            Console.Write($"\n{text}");
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
        }
        static void SortArrayBubble(int[] copyUserArrayB)// bubble sort
        {
            for (int i = 0; i < copyUserArrayB.Length - 1; i++)
            {
                for (int j = 0; j < copyUserArrayB.Length - 1 - i; j++)
                {
                    if (copyUserArrayB[j] > copyUserArrayB[j + 1])
                    {
                        int c = copyUserArrayB[j];
                        copyUserArrayB[j] = copyUserArrayB[j + 1];
                        copyUserArrayB[j + 1] = c;
                    }
                }
            }
        }
        static void SortArrayShell(int[] copyUserArrayS)// shell sort
        {
            for (int smallArrayLength = copyUserArrayS.Length / 2; smallArrayLength > 0; smallArrayLength /= 2)
            {
                for (int i = smallArrayLength; i < copyUserArrayS.Length; i++)
                {
                    int c = copyUserArrayS[i];
                    int j;
                    for (j = i; j >= smallArrayLength && copyUserArrayS[j - smallArrayLength] > c; j -= smallArrayLength)
                    {
                        copyUserArrayS[j] = copyUserArrayS[j - smallArrayLength];
                    }
                    copyUserArrayS[j] = c;
                }
            }
        }
        //4
        static void ConnectFourGame()//main game
        {
            bool playAgain = true;
            while(playAgain)
            {
                char[,] gameBoard = InitializeBoard();
                char currentPlayer = 'X';
                bool gameRunning = true;
                bool playerWon = false;

                while (gameRunning)
                {
                    int playerMove = GetPlayerInput(gameBoard, currentPlayer);
                    bool isLegalMove = PlayerMove(gameBoard, playerMove, currentPlayer);
                    if (!isLegalMove)
                    {
                        WaitKey("Invalid move! Column is full. Press any key to try again...");
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
        static char SwitchPlayer(char currentPlayer)// switch between player
        {
            if(currentPlayer == 'X')
                return 'O';
            else
                return 'X';
        }
        static void DisplayDraw(char[,] gameBoard)// write if game result are draw
        {
            Console.WriteLine("===== Result =====");
            DisplayBoard(gameBoard);
            Console.WriteLine("\nIt's a draw!");
        }
        static void DisplayWinner(char[,] gameBoard, char currentPlayer)// write if we have a winner
        {
            Console.WriteLine("===== Result =====");
            DisplayBoard(gameBoard);
            Console.WriteLine($"\nPlayer {currentPlayer} wins!");
        }
        static char[,] InitializeBoard()// create board for a game
        {
            const int Rows = 6;
            const int Columns = 7;
            char[,] gameBoard= new char[Rows, Columns];
            for (int row = 0; row < Rows; row++)
            {
                for(int col = 0; col < Columns; col++)
                {
                    gameBoard[row, col] = '.';
                }
            }
            return gameBoard;
        }
        static void DisplayBoard(char[,] gameBoard)// show game board on console
        {
            Console.WriteLine("\n  1 2 3 4 5 6 7");
            for(int row = 0; row < gameBoard.GetLength(0); row++)
            {
                Console.Write("| ");
                for(int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    Console.Write(gameBoard[row,col] + " ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("+---------------+");
        }
        static int GetPlayerInput(char[,] gameBoard, char currentPlayer)// get input from console
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Game =====");
                DisplayBoard(gameBoard);
                Console.Write("\n Player {0}, enter column (1-7): ", currentPlayer);

                string input = Console.ReadLine();

                if(int.TryParse(input, out int inputColumn) && inputColumn >= 1 && inputColumn <= 7)
                {
                    return inputColumn - 1;
                }
                else
                {
                    WaitKey("Error, invalid value...");
                }
            }
        }
        static bool PlayerMove(char[,] gameBoard, int column, char currentPlayer)// try make a move from player input return true if successful 
        {
            for(int i = gameBoard.GetLength(0) - 1; i >= 0; i--)
            {
                if (gameBoard[i, column] == '.')
                {
                    gameBoard[i, column] = currentPlayer;
                    return true;
                }
            }
            return false;
        }
        static bool CheckForWin(char[,] gameBoard, char currentPlayer)// check after every move, true current player win
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
        static bool CheckForDraw(char[,] gameBoard)// check after every move, true if board fill
        {
            for(int row = 0; row < gameBoard.GetLength(0); row++)
            {
                for(int col = 0; col < gameBoard.GetLength(1); col++)
                {
                    if (gameBoard[row,col] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        static bool PlayAgain()// ask if player want to play again
        {
            while (true)
            {

                Console.WriteLine("\n===== Restart Game? =====");
                Console.Write("Play again? (y/n): ");
                string answer = Console.ReadLine().ToLower();

                if(answer == "y")
                {
                    return true;
                }
                else if(answer == "n")
                {
                    return false;
                }
                else
                {
                    WaitKey("Error, invalid value...");
                    Console.Clear();
                }
            }
        }
        //other
        static bool CloseProg()// confirm exit return bool
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
        static double GetDouble(string text = "Enter value: ")// get double with validation
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
        static void WaitKey(string text = "Press any key to continue... ")// ReadKey() + write a text
        {
            Console.Write("\n" + text);
            Console.ReadKey(true);
        }
    }
}
