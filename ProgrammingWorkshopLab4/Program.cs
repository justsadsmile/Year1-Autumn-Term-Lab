using System;

namespace ProgrammingWorkshopLab4
{
    class Program
    {
        private static BmiAnalyzer analyzer;

        static Program()
        {
            analyzer = new BmiAnalyzer();
        }

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== BMI Analyzer (OOP) ===");
                Console.WriteLine("1. New measurement");
                Console.WriteLine("2. Measurement history");
                Console.WriteLine("3. Analyze trends");
                Console.WriteLine("4. Compare measurements");
                Console.WriteLine("5. Show graph");
                Console.WriteLine("6. Recommendations");
                Console.WriteLine("0. Exit");

                Console.Write("\nChoose action: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewMeasurement();
                        break;
                    case "2":
                        analyzer.ShowHistory();
                        PauseProgram();
                        break;
                    case "3":
                        analyzer.AnalyzeTrends();
                        PauseProgram();
                        break;
                    case "4":
                        CompareMeasurementsMenu();
                        break;
                    case "5":
                        analyzer.ShowGraph();
                        PauseProgram();
                        break;
                    case "6":
                        ShowRecommendations();
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        PauseProgram("Invalid choice. Press any key to try again...");
                        break;
                }
            }
        }

        static void CreateNewMeasurement()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("=== New BMI Measurement ===\n");

                double weight = GetValidDoubleInput("Enter weight (30-300 kg): ", 30.0, 300.0);
                double height = GetHeightInput();
                string gender = GetGenderInput();
                int age = GetValidIntInput("Enter age (1-120): ", 1, 120);

                BmiMeasurement measurement = new BmiMeasurement(weight, height, gender, age);
                analyzer.AddMeasurement(measurement);

                Console.WriteLine("\nMeasurement saved successfully!");
                measurement.PrintReport();

                PauseProgram();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                PauseProgram();
            }
        }

        static int GetValidIntInput(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                Console.WriteLine("Please enter a value between {0} and {1}", min.ToString(), max.ToString());
            }
        }

        static double GetValidDoubleInput(string prompt, double min, double max)
        {
            while (true)
            {
                Console.Write(prompt);
                if (Double.TryParse(Console.ReadLine(), out double value))
                {
                    if (value >= min && value <= max)
                    {
                        return value;
                    }
                }
                Console.WriteLine("Please enter a value between {0} and {1}", min.ToString(), max.ToString());
            }
        }

        static double GetHeightInput()
        {
            while (true)
            {
                Console.Write("Enter height (in meters or cm): ");
                if (Double.TryParse(Console.ReadLine(), out double height))
                {
                    if (height >= 100.0 && height <= 250.0)
                    {
                        return height / 100.0;
                    }

                    if (height >= 1.0 && height <= 2.5)
                    {
                        return height;
                    }
                }
                Console.WriteLine("Please enter height between 1.0-2.5m or 100-250cm");
            }
        }

        static string GetGenderInput()
        {
            while (true)
            {
                Console.Write("Enter gender (m/f): ");
                string input = Console.ReadLine();
                if (input != null)
                {
                    input = input.ToLower();
                }

                if (input == "m" || input == "f")
                {
                    return input;
                }
                Console.WriteLine("Please enter 'm' for male or 'f' for female");
            }
        }

        static void CompareMeasurementsMenu()
        {
            analyzer.ShowHistory();

            if (analyzer.MeasurementCount < 2)
            {
                Console.WriteLine("\nNeed at least 2 measurements to compare.");
                PauseProgram();
                return;
            }

            Console.Write("\nEnter first measurement index (0-{0}): ", (analyzer.MeasurementCount - 1).ToString());
            string input1 = Console.ReadLine();
            if (Int32.TryParse(input1, out int index1))
            {
                Console.Write("Enter second measurement index (0-{0}): ", (analyzer.MeasurementCount - 1).ToString());
                string input2 = Console.ReadLine();
                if (Int32.TryParse(input2, out int index2))
                {
                    analyzer.CompareMeasurements(index1, index2);
                }
            }

            PauseProgram();
        }

        static void ShowRecommendations()
        {
            if (analyzer.MeasurementCount == 0)
            {
                Console.WriteLine("No measurements available. Create a measurement first.");
                PauseProgram();
                return;
            }

            BmiMeasurement latest = analyzer.GetMeasurement(analyzer.MeasurementCount - 1);

            Console.Clear();
            Console.WriteLine("=== Recommendations ===\n");
            Console.WriteLine("Latest measurement ({0}):", latest.MeasurementDate.ToString("dd.MM.yyyy"));
            Console.WriteLine("BMI: {0} ({1})", latest.BmiValue.ToString("F1"), latest.Category);
            Console.WriteLine("Age: {0}, Gender: {1}", latest.Age.ToString(), (latest.Gender == "m" ? "Male" : "Female"));

            Console.WriteLine();

            Console.WriteLine(latest.GetRecommendations());

            double idealWeight = latest.CalculateIdealWeight();
            if (idealWeight > 0.0)
            {
                Console.WriteLine("\nIdeal weight for your height ({0}m): {1} kg", latest.Height.ToString("F2"), idealWeight.ToString("F1"));
            }

            PauseProgram();
        }

        static void PauseProgram(string text = "Press any key to continue...")
        {
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}