using System;

namespace FinancialForecasting
{
    class Program
    {
        static void Main(string[] args)
        {
            double presentValue = 1000.0;
            double growthRate = 0.05; // 5% growth rate
            int years = 10;

            double futureValue = CalculateFutureValue(presentValue, growthRate, years);

            Console.WriteLine($"Present Value: {presentValue}");
            Console.WriteLine($"Growth Rate: {growthRate:P}");
            Console.WriteLine($"Years: {years}");
            Console.WriteLine($"Future Value (Recursive): {futureValue:F2}");
        }

        public static double CalculateFutureValue(double currentValue, double growthRate, int remainingYears)
        {
            if (remainingYears <= 0)
            {
                return currentValue;
            }

            double nextValue = currentValue * (1 + growthRate);
            return CalculateFutureValue(nextValue, growthRate, remainingYears - 1);
        }
    }
}
