using System;

namespace ProgrammingWorkshopLab4
{
    public class BmiAnalyzer
    {
        private BmiMeasurement[] measurements;
        private int currentIndex;
        private int measurementCount;

        public BmiAnalyzer()
        {
            measurements = new BmiMeasurement[10];
            currentIndex = 0;
            measurementCount = 0;
        }

        public void AddMeasurement(BmiMeasurement measurement)
        {
            if (measurementCount >= 10)
            {
                for (int i = 0; i < 9; i = i + 1)
                {
                    measurements[i] = measurements[i + 1];
                }
                measurementCount = 9;
                currentIndex = 9;
            }

            measurements[currentIndex] = measurement;
            measurementCount = measurementCount + 1;
            currentIndex = measurementCount % 10;
        }

        public void ShowHistory()
        {
            Console.Clear();
            Console.WriteLine("=== Measurement History ===\n");

            if (measurementCount == 0)
            {
                Console.WriteLine("No measurements recorded.");
            }
            else
            {
                Console.WriteLine("Date\t\tWeight\tHeight\tAge\tGender\tBMI\tCategory");
                Console.WriteLine("------------------------------------------------------------");

                for (int i = 0; i < measurementCount; i = i + 1)
                {
                    BmiMeasurement m = measurements[i];
                    Console.WriteLine(m.MeasurementDate.ToString("dd.MM.yyyy") + "\t" +
                                    m.Weight.ToString() + "\t" +
                                    m.Height.ToString("F2") + "\t" +
                                    m.Age.ToString() + "\t" +
                                    m.Gender + "\t" +
                                    m.BmiValue.ToString("F1") + "\t" +
                                    m.Category);
                }
            }
        }

        public void AnalyzeTrends()
        {
            Console.Clear();
            Console.WriteLine("=== Trends Analysis ===\n");

            if (measurementCount == 0)
            {
                Console.WriteLine("No data for analysis.");
                return;
            }

            Console.WriteLine("Total measurements: {0}", measurementCount.ToString());

            double sum = 0.0;
            double maxBmi = measurements[0].BmiValue;
            double minBmi = measurements[0].BmiValue;
            DateTime firstDate = measurements[0].MeasurementDate;
            DateTime lastDate = measurements[measurementCount - 1].MeasurementDate;

            for (int i = 0; i < measurementCount; i = i + 1)
            {
                double bmi = measurements[i].BmiValue;
                sum = sum + bmi;

                if (bmi > maxBmi)
                {
                    maxBmi = bmi;
                }
                if (bmi < minBmi)
                {
                    minBmi = bmi;
                }
            }

            double averageBmi = sum / (double)measurementCount;

            Console.WriteLine("Average BMI: {0}", averageBmi.ToString("F1"));

            if (measurementCount > 1)
            {
                Console.WriteLine("Period: {0} - {1}", firstDate.ToString("dd.MM.yyyy"), lastDate.ToString("dd.MM.yyyy"));
                Console.WriteLine("BMI Range: {0} - {1}", minBmi.ToString("F1"), maxBmi.ToString("F1"));

                double firstBmi = measurements[0].BmiValue;
                double lastBmi = measurements[measurementCount - 1].BmiValue;
                double change = lastBmi - firstBmi;

                string changeString;
                if (change > 0.0)
                {
                    changeString = "+" + change.ToString("F2");
                }
                else if (change < 0.0)
                {
                    changeString = change.ToString("F2");
                }
                else
                {
                    changeString = "0";
                }

                Console.WriteLine("Overall Change: {0} ({1} -> {2})", changeString, firstBmi.ToString("F1"), lastBmi.ToString("F1"));

                DateTime monthAgo = DateTime.Now.AddDays(-30.0);
                double firstRecentBmi = 0.0;
                double lastRecentBmi = 0.0;
                bool foundRecent = false;

                for (int i = 0; i < measurementCount; i = i + 1)
                {
                    if (measurements[i].MeasurementDate >= monthAgo)
                    {
                        if (!foundRecent)
                        {
                            firstRecentBmi = measurements[i].BmiValue;
                            foundRecent = true;
                        }
                        lastRecentBmi = measurements[i].BmiValue;
                    }
                }

                if (foundRecent && firstRecentBmi != 0.0)
                {
                    double monthlyChange = lastRecentBmi - firstRecentBmi;
                    string monthlyChangeString;
                    if (monthlyChange > 0.0)
                    {
                        monthlyChangeString = "+" + monthlyChange.ToString("F2");
                    }
                    else if (monthlyChange < 0.0)
                    {
                        monthlyChangeString = monthlyChange.ToString("F2");
                    }
                    else
                    {
                        monthlyChangeString = "0";
                    }
                    Console.WriteLine("Monthly Change: {0}", monthlyChangeString);
                }
            }
        }

        public void CompareMeasurements(int index1, int index2)
        {
            if (index1 < 0 || index1 >= measurementCount || index2 < 0 || index2 >= measurementCount)
            {
                Console.WriteLine("Invalid measurement indices.");
                return;
            }

            BmiMeasurement m1 = measurements[index1];
            BmiMeasurement m2 = measurements[index2];

            Console.WriteLine("=== Measurement Comparison ===");
            Console.WriteLine("\nMeasurement 1 ({0}):", m1.MeasurementDate.ToString("dd.MM.yyyy"));
            Console.WriteLine("  BMI: {0} ({1})", m1.BmiValue.ToString("F1"), m1.Category);

            Console.WriteLine("\nMeasurement 2 ({0}):", m2.MeasurementDate.ToString("dd.MM.yyyy"));
            Console.WriteLine("  BMI: {0} ({1})", m2.BmiValue.ToString("F1"), m2.Category);

            double change = m2.BmiValue - m1.BmiValue;
            string changeString;
            if (change > 0.0)
            {
                changeString = "+" + change.ToString("F2");
            }
            else if (change < 0.0)
            {
                changeString = change.ToString("F2");
            }
            else
            {
                changeString = "0";
            }

            Console.WriteLine("\nChange: {0} points", changeString);

            TimeSpan timeBetween = m2.MeasurementDate - m1.MeasurementDate;
            Console.WriteLine("Time between: {0} days", timeBetween.Days.ToString());
        }

        public void ShowGraph()
        {
            if (measurementCount < 2)
            {
                Console.WriteLine("Need at least 2 measurements for graph.");
                return;
            }

            Console.WriteLine("\n=== BMI Change Graph ===");
            Console.WriteLine("(Each * represents 0.5 BMI points)\n");

            double min = measurements[0].BmiValue;
            double max = measurements[0].BmiValue;

            for (int i = 1; i < measurementCount; i = i + 1)
            {
                if (measurements[i].BmiValue < min)
                {
                    min = measurements[i].BmiValue;
                }
                if (measurements[i].BmiValue > max)
                {
                    max = measurements[i].BmiValue;
                }
            }

            int graphHeight = 10;
            double scale = (max - min) / (double)graphHeight;

            for (int i = 0; i < measurementCount; i = i + 1)
            {
                int stars = (int)((measurements[i].BmiValue - min) / scale);
                string starString = "";
                for (int j = 0; j < stars; j = j + 1)
                {
                    starString = starString + "*";
                }
                Console.WriteLine("{0}: {1} ({2})", measurements[i].MeasurementDate.ToString("dd.MM"), starString, measurements[i].BmiValue.ToString("F1"));
            }
        }

        public int MeasurementCount
        {
            get
            {
                return measurementCount;
            }
        }

        public BmiMeasurement GetMeasurement(int index)
        {
            return measurements[index];
        }
    }
}