using System;

namespace ProgrammingWorkshopLab2
{
    class Program
    {
        private static double[] weights = new double[10];
        private static double[] heights = new double[10];
        private static string[] genders = new string[10];
        private static int[] ages = new int[10];
        private static double[] bmiResults = new double[10];
        private static DateTime[] dates = new DateTime[10];
        private static int measurementCount = 0;

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== BMI Analyzer ===");
                Console.WriteLine("1. New calculation");
                Console.WriteLine("2. Measurement history");
                Console.WriteLine("3. Dynamics analysis");
                Console.WriteLine("4. Recommendations");
                Console.WriteLine("5. Exit");

                Console.Write("\nChoose action: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateBMI();
                        break;
                    case "2":
                        ShowMeasurementHistory();
                        break;
                    case "3":
                        AnalyzeDynamics();
                        break;
                    case "4":
                        ShowRecommendations();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.Write("Error, press any button to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void CalculateBMI()
        {
            try
            {
                double weight = GetWeight();
                double height = GetHeight();
                string gender = GetGender();
                int age = GetAge();

                double bmi = CalculateBMI(weight, height);
                string bmiCategory = DetermineBMICategory(bmi, age);

                SaveMeasurementToHistory(weight, height, gender, age, bmi);

                DisplayResult(bmi, bmiCategory, age, gender, height, weight);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("\nIt is recommended to consult a doctor for an accurate health assessment.");
                Console.WriteLine("\nPress any button to continue...");
                Console.ReadKey();
            }
        }

        static double GetWeight()
        {
            double weight;
            bool isValid;
            do
            {
                Console.Write("Enter weight (kg): ");
                string input = Console.ReadLine();
                isValid = double.TryParse(input, out weight);

                if (!isValid)
                {
                    Console.WriteLine("Error: enter a valid number!");
                    continue;
                }

                if (weight < 30 || weight > 300)
                {
                    Console.WriteLine("Error: weight must be between 30 and 300 kg!");
                    isValid = false;
                }
            } while (!isValid);

            return weight;
        }

        static double GetHeight()
        {
            double height;
            bool isValid;
            do
            {
                Console.Write("Enter height (m/cm): ");
                string input = Console.ReadLine();
                isValid = double.TryParse(input, out height);

                if (!isValid)
                {
                    Console.WriteLine("Error: enter a valid number!");
                    continue;
                }

                if (height >= 1.0 && height <= 2.5)
                {
                    isValid = true;
                }
                else if (height >= 100 && height <= 250)
                {
                    height = height / 100;
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: height must be between 1.0 and 2.5 m or between 100 and 250 cm!");
                    isValid = false;
                }
            } while (!isValid);

            return height;
        }

        static string GetGender()
        {
            string gender;
            bool isValid;
            do
            {
                Console.Write("Enter gender (m/f): ");
                gender = Console.ReadLine().ToLower();

                if (gender == "m" || gender == "f")
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Error: enter 'm' for male or 'f' for female!");
                    isValid = false;
                }
            } while (!isValid);

            return gender;
        }

        static int GetAge()
        {
            int age;
            bool isValid;
            do
            {
                Console.Write("Enter age: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out age);

                if (!isValid)
                {
                    Console.WriteLine("Error: enter a valid number!");
                    continue;
                }

                if (age < 1 || age > 120)
                {
                    Console.WriteLine("Error: age must be between 1 and 120 years!");
                    isValid = false;
                }
            } while (!isValid);

            return age;
        }

        static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }

        static string DetermineBMICategory(double bmi, int age)
        {
            // Adjust BMI based on age
            double adjustedBmi = bmi;
            if (age >= 0 && age <= 18)
            {
                adjustedBmi = bmi + 1;
            }
            else if (age >= 25 && age <= 34)
            {
                adjustedBmi = bmi - 1;
            }
            else if (age >= 35 && age <= 44)
            {
                adjustedBmi = bmi - 2;
            }
            else if (age >= 45 && age <= 54)
            {
                adjustedBmi = bmi - 3;
            }
            else if (age >= 55 && age <= 64)
            {
                adjustedBmi = bmi - 4;
            }
            else if (age >= 65)
            {
                adjustedBmi = bmi - 5;
            }

            if (adjustedBmi <= 16)
            {
                return "Pronounced deficiency";
            }
            else if (adjustedBmi <= 18.5)
            {
                return "Underweight";
            }
            else if (adjustedBmi <= 25.0)
            {
                return "Normal";
            }
            else if (adjustedBmi <= 30.0)
            {
                return "Overweight";
            }
            else if (adjustedBmi <= 35.0)
            {
                return "Obesity grade 1";
            }
            else if (adjustedBmi <= 40.0)
            {
                return "Obesity grade 2";
            }
            else
            {
                return "Obesity grade 3";
            }
        }

        static void SaveMeasurementToHistory(double weight, double height, string gender, int age, double bmi)
        {
            if (measurementCount >= 10)
            {
                for (int i = 0; i < 9; i++)
                {
                    weights[i] = weights[i + 1];
                    heights[i] = heights[i + 1];
                    genders[i] = genders[i + 1];
                    ages[i] = ages[i + 1];
                    bmiResults[i] = bmiResults[i + 1];
                    dates[i] = dates[i + 1];
                }
                measurementCount = 9;
            }

            weights[measurementCount] = weight;
            heights[measurementCount] = height;
            genders[measurementCount] = gender;
            ages[measurementCount] = age;
            bmiResults[measurementCount] = bmi;
            dates[measurementCount] = DateTime.Now;

            measurementCount++;
        }

        static void ShowMeasurementHistory()
        {
            Console.Clear();
            Console.WriteLine("=== Measurement History ===\n");

            if (measurementCount == 0)
            {
                Console.WriteLine("Measurement history is empty.");
            }
            else
            {
                Console.WriteLine("Date\t\tWeight\tHeight\tAge\tGender\tBMI\tCategory");
                Console.WriteLine("------------------------------------------------------------");

                for (int i = 0; i < measurementCount; i++)
                {
                    string category = DetermineBMICategory(bmiResults[i], ages[i]);
                    Console.WriteLine($"{dates[i]:dd.MM.yyyy}\t{weights[i]}\t{heights[i]:F2}\t{ages[i]}\t{genders[i]}\t{bmiResults[i]:F1}\t{category}");
                }
            }

            Console.WriteLine("\nPress any button to continue...");
            Console.ReadKey();
        }

        static void AnalyzeDynamics()
        {
            Console.Clear();
            Console.WriteLine("=== Dynamics Analysis ===\n");

            if (measurementCount == 0)
            {
                Console.WriteLine("No data for analysis.");
            }
            else
            {
                Console.WriteLine($"Total measurements: {measurementCount}");

                // Calculate average BMI without LINQ
                double sum = 0;
                for (int i = 0; i < measurementCount; i++)
                {
                    sum += bmiResults[i];
                }
                double averageBMI = sum / measurementCount;
                Console.WriteLine($"Average BMI: {averageBMI:F1}");

                if (measurementCount > 1)
                {
                    // Calculate max and min BMI without LINQ
                    double maxBMI = bmiResults[0];
                    double minBMI = bmiResults[0];
                    int maxIndex = 0;
                    int minIndex = 0;

                    for (int i = 1; i < measurementCount; i++)
                    {
                        if (bmiResults[i] > maxBMI)
                        {
                            maxBMI = bmiResults[i];
                            maxIndex = i;
                        }
                        if (bmiResults[i] < minBMI)
                        {
                            minBMI = bmiResults[i];
                            minIndex = i;
                        }
                    }

                    Console.WriteLine($"Maximum BMI: {maxBMI:F1} ({dates[maxIndex]:dd.MM.yyyy})");
                    Console.WriteLine($"Minimum BMI: {minBMI:F1} ({dates[minIndex]:dd.MM.yyyy})");

                    // Change over last month (if there's data from last 30 days)
                    DateTime monthAgo = DateTime.Now.AddDays(-30);
                    double firstBMI = 0;
                    double lastBMI = 0;
                    bool foundFirst = false;
                    bool foundLast = false;

                    for (int i = 0; i < measurementCount; i++)
                    {
                        if (dates[i] >= monthAgo)
                        {
                            if (!foundFirst)
                            {
                                firstBMI = bmiResults[i];
                                foundFirst = true;
                            }
                            lastBMI = bmiResults[i];
                            foundLast = true;
                        }
                    }

                    if (foundFirst && foundLast && firstBMI != 0 && lastBMI != 0)
                    {
                        double change = lastBMI - firstBMI;
                        Console.WriteLine($"Change over last month: {change:+#.##;-#.##;0}");
                    }
                    else
                    {
                        Console.WriteLine("Change over last month: insufficient data");
                    }
                }
            }
            Console.ReadKey();
            
        }

        static void ShowRecommendations()
        {
            Console.Clear();
            Console.WriteLine("=== Recommendations ===\n");

            if (measurementCount == 0)
            {
                Console.WriteLine("First calculate BMI to get recommendations.");
            }
            else
            {
                double latestBMI = bmiResults[measurementCount - 1];
                int latestAge = ages[measurementCount - 1];
                string latestGender = genders[measurementCount - 1];
                double latestHeight = heights[measurementCount - 1];

                string category = DetermineBMICategory(latestBMI, latestAge);
                Console.WriteLine($"Your BMI category: {category}");
                Console.WriteLine();

                if (category == "Pronounced deficiency" || category == "Underweight")
                {
                    Console.WriteLine("Recommendations:");
                    Console.WriteLine("- Increase calorie intake");
                    Console.WriteLine("- Include protein-rich foods in your diet");
                    Console.WriteLine("- Do regular strength training");
                    Console.WriteLine("- Consult a nutritionist");
                }
                else if (category == "Normal")
                {
                    Console.WriteLine("Recommendations:");
                    Console.WriteLine("- Maintain your current eating habits");
                    Console.WriteLine("- Engage in regular physical activity");
                    Console.WriteLine("- Monitor diet balance");
                }
                else
                {
                    Console.WriteLine("Recommendations:");
                    Console.WriteLine("- Reduce calorie intake");
                    Console.WriteLine("- Increase physical activity");
                    Console.WriteLine("- Limit sweets and fatty foods");
                    Console.WriteLine("- Consult a doctor");
                }

                // Ideal weight calculation
                Console.WriteLine("\nIdeal weight:");
                double idealWeight = CalculateIdealWeight(latestHeight, latestGender);
                Console.WriteLine($"For height {latestHeight:F2} m: {idealWeight:F1} kg");
            }

            Console.WriteLine("\nPress any button to continue...");
            Console.ReadKey();
        }

        static double CalculateIdealWeight(double height, string gender)
        {
            height = height * 100; // convert to cm

            if (height < 135)
            {
                return 0; // not calculated for height less than 135 cm
            }

            if (gender == "m")
            {
                return height - (100 + (height - 100) / 20);
            }
            else
            {
                return height - (100 + (height - 100) / 10);
            }
        }

        static void DisplayResult(double bmi, string bmiCategory, int age, string gender, double height, double weight)
        {
            Console.Clear();
            Console.WriteLine("=== Calculation Results ===");
            Console.WriteLine($"Weight: {weight} kg");
            Console.WriteLine($"Height: {height:F2} m");
            Console.WriteLine($"Gender: {gender}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"\nYour BMI: {bmi:F2}");
            Console.WriteLine($"Category: {bmiCategory}");
        }
    }
}