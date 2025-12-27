using System;

namespace BasicProgrammingLab6
{
    /// <summary>
    /// Class for calculating the value of a mathematical function
    /// </summary>
    public static class FunctionCalculator
    {
        private const double PI = Math.PI;
        private const double E = Math.E;

        /// <summary>
        /// Calculates the function value using the formula
        /// </summary>
        /// <param name="a">Parameter a</param>
        /// <param name="b">Parameter b (must be > 0)</param>
        /// <returns>Calculation result</returns>
        public static double Calculate(double a, double b)
        {
            if (b <= 0)
                throw new ArgumentException("Value b must be greater than 0", nameof(b));

            double denominator = Math.Sin(Math.Pow((PI / 2) + a, 2));

            if (Math.Abs(denominator) < 0.0000001)
                throw new ArgumentException("Denominator cannot be 0", nameof(a));

            double result = (Math.Pow(Math.Cos(PI), 7) +
                           Math.Sqrt(Math.Log(Math.Pow(b, 4), E))) /
                           denominator;

            return Math.Round(result, 4);
        }

        /// <summary>
        /// Validates parameters before calculation
        /// </summary>
        public static bool ValidateParameters(double a, double b, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (b <= 0)
            {
                errorMessage = "Value b must be greater than 0";
                return false;
            }

            double denominator = Math.Sin(Math.Pow((PI / 2) + a, 2));
            if (Math.Abs(denominator) < 0.0000001)
            {
                errorMessage = "Invalid value a: denominator equals 0";
                return false;
            }

            return true;
        }
    }
}