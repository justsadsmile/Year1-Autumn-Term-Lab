using System;

namespace ProgrammingWorkshopLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            const double minBMI = 18.5;
            const double maxBMI = 24.9;

            Console.Write("Enter weight(kg): ");
            string stgWeight = Console.ReadLine();
            double weight = double.Parse(stgWeight);

            Console.Write("Enter height(m): ");
            string stgHeight = Console.ReadLine();
            double height = double.Parse(stgHeight);

            //calculation
            double a;
            a = Math.Pow(height, 2);
            a = weight / a;

            //formatting the result
            string formatA = string.Format("{0:f2}", a);

            //output the result
            Console.WriteLine(formatA);
            if (a <= minBMI)//output the interpretation
            {
                Console.WriteLine("Flaw");
            }
            else if (a >= maxBMI)
            {
                Console.WriteLine("Overweight");
            }
            else
            {
                Console.WriteLine("Norm");
            }
        }
    }
}