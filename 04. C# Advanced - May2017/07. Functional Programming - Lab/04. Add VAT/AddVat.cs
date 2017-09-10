using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.Add_VAT
{
    public class AddVat
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToList()
                .ForEach(n => Console.WriteLine($"{n * 1.2:f2}"));
        }
    }
}
