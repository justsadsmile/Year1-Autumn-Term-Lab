using System;
using System.Windows.Forms;

namespace BasicProgrammingLab6
{
    /// <summary>
    /// Class for validating user input
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Checks if a string is a valid double number
        /// </summary>
        public static bool TryParseDouble(string input, out double result, out string errorMessage)
        {
            result = 0;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Field cannot be empty";
                return false;
            }

            if (!double.TryParse(input, out result))
            {
                errorMessage = "Enter a valid number";
                return false;
            }

            if (double.IsInfinity(result) || double.IsNaN(result))
            {
                errorMessage = "Number has an invalid value";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if a string is a valid integer number
        /// </summary>
        public static bool TryParseInt(string input, out int result, out string errorMessage)
        {
            result = 0;
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = "Field cannot be empty";
                return false;
            }

            if (!int.TryParse(input, out result))
            {
                errorMessage = "Enter an integer number";
                return false;
            }

            if (result <= 0)
            {
                errorMessage = "Number of attempts must be greater than 0";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Sets an error message for a control
        /// </summary>
        public static void SetError(Control control, string errorMessage)
        {
            if (control is TextBox textBox)
            {
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    textBox.BackColor = System.Drawing.Color.LightPink;
                    textBox.Select();
                }
                else
                {
                    textBox.BackColor = System.Drawing.Color.White;
                }
            }
        }
    }
}