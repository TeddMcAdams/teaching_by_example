using System;

namespace input_10_values
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            double[] userNumbers = AskUserForNoMoreThanTenNumbers();
            
            if (userNumbers.Length == 0)
            {
                Console.WriteLine("Error: Program can only accept ten numbers.");
                return;
            }
            
            double mean = CalculateMeanForUserNumbers(userNumbers);
            Console.WriteLine($"The mean is: {mean}");

            double variance = CalculateVarianceForUserNumbers(userNumbers, mean);
            Console.WriteLine($"The variance is: {variance}");

            double deviation = CalculateDeviationFromVariance(variance);
            Console.WriteLine($"The deviation is: {deviation}");

            Console.Write("end");
            Console.ReadKey();
        }

        static double[] AskUserForNoMoreThanTenNumbers()
        {
            double[] numbers = new double[10];

            for (int i = 0; i < numbers.Length + 1; i++)
            {
                if (i > 9)
                {
                    Console.Write("Please enter a negative number to stop: ");
                }
                else
                {
                    Console.Write($"Enter a number (limit of ten, negative to stop) #{i + 1}: ");
                }

                string userInput = Console.ReadLine();
                double userNumber = double.Parse(userInput);

                if (userNumber < 0)
                {
                    numbers[i] = userNumber;
                    break;
                }
                else if (i > 9)
                {
                    return new double[0];
                }
                else
                {
                    numbers[i] = userNumber;
                }
            }

            return numbers;
        }
    
        static double CalculateMeanForUserNumbers(double[] userNumbers)
        {
            double mean;
            double sum = 0;
            int i = 0;
            
            while (i < 10 && userNumbers[i] > -1)
            {
                sum += userNumbers[i];
                i++;
            }
            
            mean = sum / i;

            return mean;
        }
  
        static double CalculateVarianceForUserNumbers(double[] userNumbers, double mean)
        {
            double variance;
            double sumOfResults = 0;
            int i = 0;

            while (i < 10 && userNumbers[i] > -1)
            {
                sumOfResults += Math.Pow(userNumbers[i] - mean, 2);
                i++;
            }

            variance = sumOfResults / i;

            return variance;
        }

        static double CalculateDeviationFromVariance(double variance)
        {
            return Math.Sqrt(variance);
        }
    }
}
