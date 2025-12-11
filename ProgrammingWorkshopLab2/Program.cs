using System;

namespace ProgrammingWorkshopLab2
{
    class Program
    {
        static void Main(string[] args)//Selection menu
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== BMI calculator ===");
                Console.WriteLine("1. Calculate your BMI");
                Console.WriteLine("2. Exit");

                Console.Write("\nChoice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateIMT();
                        break;
                    case "2":
                        running = false;
                        break;
                    default:
                        Console.Write("Error, press any button to try again...");
                        Console.ReadKey();
                        break;
                }
            }

        }
        static void CalculateIMT()//Basic
        {
            try
            {
                //Input weight
                double weight = GetWeight();
                //Input height
                double height = GetHeight();
                //Enter gender
                char gender = GetGender();
                //Enter age
                uint age = GetAge();
                //Calculating BMI
                double bmi = GetBmi(weight, height);
                //Formatting the BMI result
                string formatBMI = GetFormatBmi(bmi);

                OutputDetail(formatBMI, age, gender, height, weight);
                //Result output + taking into age + taking into gender
                DisplayResult(bmi, formatBMI, age, gender, height);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);//Output when an error is detected
            }
            finally
            {
                Console.WriteLine("\nIt is recommended to consult a doctor for an accurate health assessment.");
                Console.WriteLine("\nPress any button to finish...");
                Console.ReadKey();//End program
            }
        }
        static double GetWeight()//Input weight
        {
            double weight;
            bool checking = false;
            do
            {
                do
                {
                    Console.Write("Enter weight (kg): ");
                    string stgWeight = Console.ReadLine();
                    checking = double.TryParse(stgWeight, out weight);
                } while (checking == false);
                if (weight >= 30 && weight <= 300)
                {
                    checking = true;
                }
                else
                {
                    checking = false;
                }
            } while (checking == false);
            return weight;
        }
        static double GetHeight()//Input height
        {
            double height;
            bool checking = false;
            do
            {
                do
                {
                    Console.Write("Enter your height (m/cm): ");
                    string stgHeight = Console.ReadLine();
                    checking = double.TryParse(stgHeight, out height);
                } while (checking == false);
                if (height >= 1.0 && height <= 2.5)
                {

                    checking = true;
                }
                else if (height >= 100 && height <= 250)
                {
                    checking = true;
                    height = height / 100;
                }
                else
                {
                    checking = false;
                }
            } while (checking == false);
            return height;
        }
        static char GetGender()//Enter gender
        {
            char gender;
            bool checking = false;
            do
            {
                do
                {
                    Console.Write("Enter gender (m/w): ");
                    string stgGender = Console.ReadLine();
                    checking = char.TryParse(stgGender, out gender);
                } while (checking == false);
                if (gender == 'm' || gender == 'w')
                {
                    checking = true;
                }
                else
                {
                    checking = false;
                }
            } while (checking == false);
            return gender;
        }
        static uint GetAge()//Enter age
        {
            bool checking = false;
            uint age;
            do
            {
                Console.Write("Enter your age: ");
                string stgAge = Console.ReadLine();
                checking = uint.TryParse(stgAge, out age);
            } while (checking == false);
            return age;
        }
        static double GetBmi(double weight, double height)//BMI calculation
        {
            double bmi;
            bmi = Math.Pow(height, 2);
            bmi = weight / bmi;
            return bmi;
        }
        static string GetFormatBmi(double bmi)//Format the BMI result
        {
            string formatBMI = string.Format("{0:f2}", bmi);
            return formatBMI;
        }
        static void OutputDetail(string formatBMI, uint age, char gender, double height, double weight)
        {
            Console.Clear();
            Console.WriteLine("Weight: {0}", weight);
            Console.WriteLine("Height: {0}", height);
            Console.WriteLine("Gender: {0}", gender);
            Console.WriteLine("Age: {0}", age);
            return;
        }
        static void DisplayResult(double bmi, string formatBMI, uint age, char gender, double height)//Output the result
        {
            Console.WriteLine("\nYour BMI: {0} ", formatBMI);//Accounting for age
            Console.Write("According to WHO standard: ");
            if (age >= 0 && age <= 18)
            {
                bmi = bmi + 1;
            }
            else if (age >= 25 && age <= 34)
            {
                bmi = bmi - 1;
            }
            else if (age >= 35 && age <= 44)
            {
                bmi = bmi - 2;
            }
            else if (age >= 45 && age <= 54)
            {
                bmi = bmi - 3;
            }
            else if (age >= 55 && age <= 64)
            {
                bmi = bmi - 4;
            }
            else
            {
                bmi = bmi - 5;
            }

            if (bmi <= 16)//Output
            {
                Console.WriteLine("Pronounced deficiency");
            }
            else if (bmi >= 16.0 && bmi <= 18.5)
            {
                Console.WriteLine("Underweight");
            }
            else if (bmi >= 18.5 && bmi <= 25.0)
            {
                Console.WriteLine("Norm");
            }
            else if (bmi >= 25.0 && bmi <= 30.0)
            {
                Console.WriteLine("Overweight");
            }
            else if (bmi >= 30.0 && bmi <= 35.0)
            {
                Console.WriteLine("Obesity grade 1");
            }
            else if (bmi >= 35.0 && bmi <= 40.0)
            {
                Console.WriteLine("Obesity grade 2");
            }
            else
            {
                Console.WriteLine("Obesity grade 3");
            }

            //Conclusion 2 taking into account gender
            double idealWeight;
            height = height * 100;
            if (height <= 134)
            {
                Console.WriteLine("Ideal weight calculation is not available for people shorter than 135 cm.");
            }
            else
            {
                Console.Write("Your ideal weight:");
                switch (gender)
                {
                    case 'm':
                        idealWeight = height - (100 + (height - 100) / 20);
                        formatIdealWeight(idealWeight);
                        break;
                    case 'w':
                        idealWeight = height - (100 + (height - 100) / 10);
                        formatIdealWeight(idealWeight);
                        break;
                }
                static string formatIdealWeight(double idealWeight)
                {
                    string formatIdealWeight = string.Format("{0:f2}", idealWeight);
                    Console.Write(formatIdealWeight);
                    Console.WriteLine("kg");
                    return formatIdealWeight;
                }
            }
        }
    }
}