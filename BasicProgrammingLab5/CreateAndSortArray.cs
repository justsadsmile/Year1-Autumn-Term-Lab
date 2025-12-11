using System;
using System.Diagnostics;

namespace BasicProgrammingLab5
{
    /// <summary>
    /// Provides array processing functionality with sorting algorithms comparison
    /// </summary>
    /// <remarks>
    /// This class creates random arrays and compares the performance of Bubble sort and Shell sort algorithms.
    /// It automatically processes arrays upon construction and provides access to the processed results.
    /// </remarks>
    public class ArrayProcessor
    {
        private int _elementCount;
        private int[] _array;

        /// <summary>
        /// Initializes a new instance of the ArrayProcessor class with default size (10 elements)
        /// </summary>
        /// <remarks>
        /// The constructor creates an array of 10 random integers and immediately processes it
        /// by comparing Bubble sort and Shell sort algorithms, displaying timing results.
        /// </remarks>
        public ArrayProcessor()
        {
            _elementCount = 10;
            _array = CreateAndFillArray(_elementCount);
            ProcessArray("Default Constructor (10 elements)");
        }

        /// <summary>
        /// Initializes a new instance of the ArrayProcessor class with specified size
        /// </summary>
        /// <param name="elementCount">The number of elements in the array to process</param>
        /// <remarks>
        /// The constructor creates an array of specified size with random integers and immediately processes it
        /// by comparing Bubble sort and Shell sort algorithms, displaying timing results.
        /// </remarks>
        /// <example>
        /// <code>
        /// var processor = new ArrayProcessor(50); // Creates and processes array with 50 elements
        /// </code>
        /// </example>
        public ArrayProcessor(int elementCount)
        {
            _elementCount = elementCount;
            _array = CreateAndFillArray(_elementCount);
            ProcessArray($"Parameter Constructor ({_elementCount} elements)");
        }

        /// <summary>
        /// Gets the processed array
        /// </summary>
        /// <value>
        /// The array that was created and can be used after processing
        /// </value>
        /// <remarks>
        /// This property provides read-only access to the internal array after initialization.
        /// The array contains random integers generated during object construction.
        /// </remarks>
        public int[] Array
        {
            get
            {
                return _array;
            }
        }

        private void ProcessArray(string title)
        {
            Console.Clear();
            Console.WriteLine($"=== {title} ===");

            int[] userArray = this.Array;

            Console.Write("\n");
            int[] copyUserArrayBubble = GetCopyArray(userArray);
            double timeBubble = GetSortTime(copyUserArrayBubble, "Bubble");

            int[] copyUserArrayShell = GetCopyArray(userArray);
            double timeShell = GetSortTime(copyUserArrayShell, "Shell");

            DisplayDifference(timeBubble, timeShell);
            DisplayArray(userArray, copyUserArrayBubble, copyUserArrayShell);
        }

        private int[] CreateAndFillArray(int n)
        {
            Random random = new Random();
            int[] userArray = new int[n];
            for (int i = 0; i < n; i++)
            {
                userArray[i] = random.Next(1000);
            }
            return userArray;
        }

        private int[] GetCopyArray(int[] userArray)
        {
            int[] copyArray = new int[userArray.Length];
            for (int i = 0; i < userArray.Length; i++)
            {
                copyArray[i] = userArray[i];
            }
            return copyArray;
        }

        private double GetSortTime(int[] array, string text)
        {
            double time;
            Stopwatch timeToDone = new Stopwatch();
            timeToDone.Start();
            switch (text)
            {
                case "Bubble":
                    SortArrayBubble(array);
                    break;
                case "Shell":
                    SortArrayShell(array);
                    break;
                default:
                    Utility.WaitKey("Error no sort was done");
                    break;
            }
            timeToDone.Stop();
            Console.WriteLine("{0} sort execution time: {1:F4} ms", text, timeToDone.Elapsed.TotalMilliseconds);
            time = timeToDone.Elapsed.TotalMilliseconds;
            return time;
        }

        private void DisplayDifference(double timeBubble, double timeShell)
        {
            double timeDifference = timeShell - timeBubble;
            if (timeBubble <= timeShell)
                Console.WriteLine($"Bubble sort is faster than Shell sort by {Math.Abs(timeDifference):F4} ms");
            else
                Console.WriteLine($"Shell sort is faster than Bubble sort by {Math.Abs(timeDifference):F4} ms");
        }

        private void DisplayArray(int[] userArray, int[] copyUserArrayB, int[] copyUserArrayS)
        {
            if (userArray.Length <= 10)
            {
                WriteArray("Original array:", userArray);
                WriteArray("Sorted array (Bubble):", copyUserArrayB);
                WriteArray("Sorted array (Shell):", copyUserArrayS);
                Utility.WaitKey();
            }
            else
                Utility.WaitKey("Arrays cannot be displayed because array length is greater than 10");
        }

        private void WriteArray(string text, int[] array)
        {
            Console.Write($"\n{text}");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }

        private void SortArrayBubble(int[] copyUserArrayB)
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

        private void SortArrayShell(int[] copyUserArrayS)
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
    }
}