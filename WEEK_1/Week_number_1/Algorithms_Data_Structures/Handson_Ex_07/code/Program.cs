using System;

class FinancialForecast
{
    // Recursive method to calculate future value
    public static double PredictValue(int years, double currentValue, double growthRate)
    {
        if (years == 0)
            return currentValue;

        return PredictValue(years - 1, currentValue, growthRate) * (1 + growthRate);
    }

    static void Main(string[] args)
    {
        double current = 10000; // Initial value
        double rate = 0.10;     // 10% growth per year
        int years = 5;

        double futureValue = PredictValue(years, current, rate);
        Console.WriteLine($"Future value after {years} years: ₹{futureValue:F2}");
    }
}
