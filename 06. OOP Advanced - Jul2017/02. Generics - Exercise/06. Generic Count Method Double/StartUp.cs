using System;

namespace _06.Generic_Count_Method_Double
{
    public class StartUp
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            double inputDouble;
            Box<double> stringBox = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                inputDouble = double.Parse(Console.ReadLine());
                stringBox.Data.Add(inputDouble);
            }

            var comparisonDouble = double.Parse(Console.ReadLine());

            Console.WriteLine(stringBox.GreaterThanCount(comparisonDouble));
        }
    }
}
