using System;

class PriceChangeAlert
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double treshold = double.Parse(Console.ReadLine());

        double initialPrice = double.Parse(Console.ReadLine());

        for (int i = 0; i < n - 1; i++)
        {
            double newPrice = double.Parse(Console.ReadLine());
            double change = PriceChange(initialPrice, newPrice);
            bool isSignificantDifference = isSignificant(change, treshold);

            string message = Get(newPrice, initialPrice, change, isSignificantDifference);
            Console.WriteLine(message);

            initialPrice = newPrice;
        }
    }

    private static string Get(double newPrice, double initialPrice, double change, bool isSignificantDifference)
    {
        string message = "";
        if (change == 0)
        {
            message = string.Format("NO CHANGE: {0}", initialPrice);
        }
        else if (!isSignificantDifference)
        {
            message = string.Format("MINOR CHANGE: {0} to {1} ({2:F2}%)", initialPrice, newPrice, change * 100);
        }
        else if (isSignificantDifference && (change > 0))
        {
            message = string.Format("PRICE UP: {0} to {1} ({2:F2}%)", initialPrice, newPrice, change * 100);
        }
        else if (isSignificantDifference && (change < 0))
            message = string.Format("PRICE DOWN: {0} to {1} ({2:F2}%)", initialPrice, newPrice, change * 100);
        return message;
    }

    private static bool isSignificant(double treshold, double change)
    {
        if (Math.Abs(treshold) >= change)
        {
            return true;
        }
        return false;
    }

    private static double PriceChange(double initialPrice, double newPrice)
    {
        double change = (newPrice - initialPrice) / initialPrice;
        return change;
    }
}
