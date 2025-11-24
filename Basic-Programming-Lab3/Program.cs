using DotNetEnv;
using System;
using System.Diagnostics;

namespace Lab3BaseProg
{
    class Program
    {
        static void Main(string[] args)//menu program
        {
            Env.Load();

            bool stopping = false;
            while (!stopping)
            {
                Console.Clear();
                Console.WriteLine("===== Menu =====");
                Console.WriteLine("1. Guess the Answer");
                Console.WriteLine("2. About the Author");
                Console.WriteLine("3. Array Sorting");
                Console.WriteLine("4. Exit");
                Console.Write("\nYour choice: ");
                string choice = Console.ReadLine();
                switch (choice)// 
                {
                    case "1":
                        GameGuestResult();//
                        break;
                    case "2":
                        AboutTheAuthor();//
                        break;
                    case "3":
                        CreateArray();//
                        break;
                    case "4":
                        stopping = CloseProg();//
                        break;
                    default:
                        WaitKey("Error, press any key to try again...");
                        break;
                }
                if (stopping)
                {
                    Console.Clear();
                    Console.Write("You have exited the program, press any key to close the window... ");
                }
            }
        }
        static void AboutTheAuthor()// about the author
        {
            string name = Environment.GetEnvironmentVariable("AUTHOR_NAME") ?? "add .env file";
            string group = Environment.GetEnvironmentVariable("AUTHOR_GROUP_NUMBER") ?? "add .env file";

            Console.Clear();
            Console.WriteLine("===== About the Author =====");
            Console.WriteLine($"Student Name: {name}\nGroup: {group}");
            WaitKey();
        }
        static bool CloseProg()// confirm exit return bool
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Exit Confirmation =====");
                Console.Write("Confirm exit from the program (y/n): ");
                string confirmation = Console.ReadLine();
                if (confirmation == "y")
                    return true;
                else if (confirmation == "n")
                    return false;
                else
                    WaitKey("Error, requesting confirmation again...");
            }
        }
        static void GameGuestResult()////guest the answer + calculation
        {
            Console.Clear();
            const double pi = Math.PI;
            bool running = true;
            double a;
            double b;
            do
            {
                a = GetDouble("Enter value a: ");
                b = GetDouble("Enter value b: ");
                if (Math.Pow(b, 4) < 0 || Math.Sin(Math.Pow(((pi / 2) + a), 2)) == 0)//check for division by zero
                {//Math.Pow(b, 4) < 0 always n >= 0, better do b == 0
                    Console.Clear();
                    WaitKey("Error, invalid value...");
                }
                else
                    running = !running;
            } while (running);
            double result = Calculation(a, b);
            GuestResult(result);
        }
        static void CreateArray()//creating and sorting an array
        {
            int n = AskLength();
            int[] userArray = CreateAndFillArray(n);
            //
            int[] copyUserArrayB = GetCopyArray(userArray);
            Stopwatch timeToDone = new Stopwatch();//
            timeToDone.Start();//measurement execution time
            copyUserArrayB = SortArrayBubble(copyUserArrayB);
            timeToDone.Stop();
            Console.WriteLine("\nBubble sort execution time: {0}", timeToDone.Elapsed);
            double timeBubble = timeToDone.Elapsed.TotalMilliseconds;
            //
            int[] copyUserArrayS = GetCopyArray(userArray);
            timeToDone.Restart();//measurement execution time
            copyUserArrayS = SortArrayShell(copyUserArrayS);
            timeToDone.Stop();
            Console.WriteLine("Shell sort execution time: {0}\n", timeToDone.Elapsed);
            double timeShell = timeToDone.Elapsed.TotalMilliseconds;
            //
            double timeDifference = timeShell - timeBubble;//comparison execution time
            if (timeBubble <= timeShell)
                Console.WriteLine($"Bubble sort is faster than Shell sort by {timeDifference:F4} ms");
            else
                Console.WriteLine($"Shell sort is faster than Bubble sort by {Math.Abs(timeDifference):F4} ms");
            OutputArray(userArray, copyUserArrayB, copyUserArrayS);
        }
        static double GetDouble(string text = "Enter value: ")//double query from console with validation
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
        static void WaitKey(string text = "Press any key to continue... ")//output text + readKey
        {
            Console.Write("\n" + text);
            Console.ReadKey();
        }
        static void GuestResult(double result)//guest the answer
        {
            int n;
            for (n = 3; n > 0; n -= 1)
            {
                Console.Clear();
                double userResult = GetDouble("===== Guess the Answer Game =====" + "\nTry to guess the answer: ");
                if (userResult == result)
                {
                    Console.WriteLine($"\nCongratulations, you guessed the answer ({result})");
                    n = -1;
                }
                else
                    WaitKey($"You have {n - 1} attempts remaining");
            }
            if (n == 0)
                WaitKey($"\nCorrect answer: {result}" + "\nPress any key to exit... ");
        }
        static int AskLength()//ask length of array return n
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
        static int[] CreateAndFillArray(int n)//create array and fill it return int[] array
        {
            Random random = new Random();//
            int[] userArray = new int[n];
            for (int i = 0; i < n; i++)//fills an array with random values
            {
                userArray[i] = random.Next(1000);
            }
            return userArray;
        }
        static int[] GetCopyArray(int[] userArray)//get copy of input array return int[] array
        {
            int[] copyArray = new int[userArray.Length];
            for (int i = 0; i < userArray.Length; i++)
            {
                copyArray[i] = userArray[i];
            }
            return copyArray;
        }
        static double Calculation(double a, double b)//calculation return double result
        {
            const double pi = Math.PI;
            const double e = Math.E;
            double result = (Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4), e))) / Math.Sin(Math.Pow(((pi / 2) + a), 2));//calculation
            result = Math.Round(result, 2);//up to 2 digits after the decimal point
            return result;
        }
        static void OutputArray(int[] userArray, int[] copyUserArrayB, int[] copyUserArrayS)//output array
        {
            if (userArray.Length <= 10)
            {
                WriteArray("Original array:\n", userArray);
                WriteArray("Sorted array (Bubble):\n", copyUserArrayB);
                WriteArray("Sorted array (Shell):\n", copyUserArrayS);
            }
            else
                WaitKey("Arrays cannot be displayed because array length is greater than 10");
            WaitKey();
        }
        static void WriteArray(string text, int[] array)//write array on console
        {
            Console.Write($"\n{text}");
            foreach (int i in array)
                Console.Write("{0} ", i);
        }
        static int[] SortArrayBubble(int[] copyUserArrayB)//bubble sort return sort array ***
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
            return copyUserArrayB;
        }//array is ref data typeno need return
        static int[] SortArrayShell(int[] copyUserArrayS)//shell sort return sort array ***
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
            return copyUserArrayS;
        }//array is ref data type no need return
    }
}