using System;

namespace ProgrammingWorkshopLab4
{
    public class BmiMeasurement
    {
        private double weight;
        private double height;
        private string gender;
        private int age;
        private DateTime measurementDate;
        private double bmiValue;
        private string category;

        public double Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (value < 30.0 || value > 300.0)
                {
                    throw new ArgumentException("Weight must be between 30 and 300 kg");
                }
                weight = value;
            }
        }

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value < 1.0 || value > 2.5)
                {
                    throw new ArgumentException("Height must be between 1.0 and 2.5 meters");
                }
                height = value;
            }
        }

        public string Gender
        {
            get
            {
                return gender;
            }
            set
            {
                if (value != "m" && value != "f")
                {
                    throw new ArgumentException("Gender must be 'm' or 'f'");
                }
                gender = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 1 || value > 120)
                {
                    throw new ArgumentException("Age must be between 1 and 120 years");
                }
                age = value;
            }
        }

        public double BmiValue
        {
            get
            {
                return bmiValue;
            }
        }

        public string Category
        {
            get
            {
                return category;
            }
        }

        public DateTime MeasurementDate
        {
            get
            {
                return measurementDate;
            }
        }

        public BmiMeasurement()
        {
            gender = String.Empty;
            category = String.Empty;
        }

        public BmiMeasurement(double weightValue, double heightValue, string genderValue, int ageValue)
        {
            Weight = weightValue;
            Height = heightValue;
            Gender = genderValue;
            Age = ageValue;
            measurementDate = DateTime.Now;
            CalculateBmi();
            DetermineCategory();
        }

        public double CalculateBmi()
        {
            bmiValue = weight / (height * height);
            return bmiValue;
        }

        public string DetermineCategory()
        {
            double adjustedBmi = bmiValue;

            if (age >= 0 && age <= 18)
            {
                adjustedBmi = bmiValue + 1.0;
            }
            else if (age >= 25 && age <= 64)
            {
                adjustedBmi = bmiValue - (((age - 25) / 10) + 1);
            }
            else if (age >= 65)
            {
                adjustedBmi = bmiValue - 5.0;
            }

            if (adjustedBmi <= 16.0)
            {
                category = "Severe underweight";
            }
            else if (adjustedBmi <= 18.5)
            {
                category = "Underweight";
            }
            else if (adjustedBmi <= 25.0)
            {
                category = "Normal";
            }
            else if (adjustedBmi <= 30.0)
            {
                category = "Overweight";
            }
            else if (adjustedBmi <= 35.0)
            {
                category = "Obesity grade 1";
            }
            else if (adjustedBmi <= 40.0)
            {
                category = "Obesity grade 2";
            }
            else
            {
                category = "Obesity grade 3";
            }

            return category;
        }

        public void PrintReport()
        {
            Console.WriteLine("=== Measurement Report ===");
            Console.WriteLine("Date: {0}", measurementDate.ToString("dd.MM.yyyy HH:mm"));
            Console.WriteLine("Weight: {0} kg", weight.ToString());
            Console.WriteLine("Height: {0} m", height.ToString("F2"));
            if (gender == "m")
            {
                Console.WriteLine("Gender: Male");
            }
            else
            {
                Console.WriteLine("Gender: Female");
            }
            Console.WriteLine("Age: {0}", age.ToString());
            Console.WriteLine("BMI: {0}", bmiValue.ToString("F2"));
            Console.WriteLine("Category: {0}", category);
        }

        public string GetRecommendations()
        {
            if (category == "Severe underweight" || category == "Underweight")
            {
                return "Recommendations:" +
                    "\n- Increase calorie intake" +
                    "\n- Include protein-rich foods" +
                    "\n- Regular strength training" +
                    "\n- Consult a nutritionist";
            }
            else if (category == "Normal")
            {
                return "Recommendations:" +
                    "\n- Maintain current diet" +
                    "\n- Regular physical activity" +
                    "\n- Monitor nutritional balance";
            }
            else
            {
                return "Recommendations:" +
                    "\n- Reduce calorie intake" +
                    "\n- Increase physical activity" +
                    "\n- Limit sweets and fatty foods" +
                    "\n- Consult a doctor";
            }
        }

        public double CalculateIdealWeight()
        {
            double heightInCm = height * 100.0;

            if (heightInCm < 135.0)
            {
                return 0.0;
            }

            if (gender == "m")
            {
                return heightInCm - (100.0 + (heightInCm - 100.0) / 20.0);
            }
            else
            {
                return heightInCm - (100.0 + (heightInCm - 100.0) / 10.0);
            }
        }
    }
}