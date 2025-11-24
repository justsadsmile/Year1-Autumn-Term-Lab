using System;

namespace mathFormula
{
    class Program
    {
        static void Main(string[] args)
        {
            const double pi = Math.PI;
            const double e = Math.E;
            string stgA;
            string stgB;
            double dResult;

            Console.Write("Enter a:");
            stgA = Console.ReadLine();
            double a = double.Parse(stgA);

            Console.Write("Enter b:");
            stgB = Console.ReadLine();
            double b = double.Parse(stgB);

            double fUp = Math.Pow(Math.Cos(pi), 7) + Math.Sqrt(Math.Log(Math.Pow(b, 4), e));
            double fDown = Math.Sin(Math.Pow(((pi / 2) + a), 2));
            dResult = fUp / fDown;

            string output = string.Format("{0:f2}", dResult);
            Console.WriteLine(output);
        }
    }
}