using System;

namespace BasicProgrammingLab6
{
    /// <summary>
    /// Class for processing one-dimensional arrays
    /// </summary>
    public class ArrayProcessor
    {
        private int[] _array;

        /// <summary>
        /// Gets or sets the array
        /// </summary>
        public int[] Array
        {
            get { return _array; }
            set { _array = value; }
        }

        /// <summary>
        /// Initializes a new instance of the ArrayProcessor class with default size (10 elements)
        /// </summary>
        public ArrayProcessor()
        {
            _array = new int[10];
        }

        /// <summary>
        /// Initializes a new instance of the ArrayProcessor class with specified size
        /// </summary>
        /// <param name="size">Number of elements in the array</param>
        public ArrayProcessor(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Array size must be greater than 0");

            _array = new int[size];
        }

        /// <summary>
        /// Fills the array with random values
        /// </summary>
        /// <param name="minValue">Minimum value (inclusive)</param>
        /// <param name="maxValue">Maximum value (exclusive)</param>
        public void FillRandom(int minValue = 0, int maxValue = 100)
        {
            Random random = new Random();
            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(minValue, maxValue);
            }
        }

        /// <summary>
        /// Performs Bubble sort on the array
        /// </summary>
        public void SortBubble()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                for (int j = 0; j < _array.Length - 1 - i; j++)
                {
                    if (_array[j] > _array[j + 1])
                    {
                        int temp = _array[j];
                        _array[j] = _array[j + 1];
                        _array[j + 1] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Performs Shell sort on the array
        /// </summary>
        public void SortShell()
        {
            for (int gap = _array.Length / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < _array.Length; i++)
                {
                    int temp = _array[i];
                    int j;
                    for (j = i; j >= gap && _array[j - gap] > temp; j -= gap)
                    {
                        _array[j] = _array[j - gap];
                    }
                    _array[j] = temp;
                }
            }
        }

        /// <summary>
        /// Finds the maximum value in the array
        /// </summary>
        /// <returns>Maximum value</returns>
        public int FindMax()
        {
            if (_array.Length == 0)
                throw new InvalidOperationException("Array is empty");

            int max = _array[0];
            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] > max)
                    max = _array[i];
            }
            return max;
        }

        /// <summary>
        /// Finds the minimum value in the array
        /// </summary>
        /// <returns>Minimum value</returns>
        public int FindMin()
        {
            if (_array.Length == 0)
                throw new InvalidOperationException("Array is empty");

            int min = _array[0];
            for (int i = 1; i < _array.Length; i++)
            {
                if (_array[i] < min)
                    min = _array[i];
            }
            return min;
        }

        /// <summary>
        /// Calculates the average value of array elements
        /// </summary>
        /// <returns>Average value</returns>
        public double CalculateAverage()
        {
            if (_array.Length == 0)
                return 0;

            double sum = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                sum += _array[i];
            }
            return sum / _array.Length;
        }

        /// <summary>
        /// Finds all indices of a specific value in the array
        /// </summary>
        /// <param name="value">Value to search for</param>
        /// <returns>Array of indices where the value is found</returns>
        public int[] FindValueIndices(int value)
        {
            int count = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                    count++;
            }

            int[] indices = new int[count];
            int index = 0;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] == value)
                    indices[index++] = i;
            }

            return indices;
        }

        /// <summary>
        /// Checks if array is sorted in ascending order
        /// </summary>
        /// <returns>True if array is sorted, false otherwise</returns>
        public bool IsSorted()
        {
            for (int i = 0; i < _array.Length - 1; i++)
            {
                if (_array[i] > _array[i + 1])
                    return false;
            }
            return true;
        }
    }
}