using System;
using System.Globalization;

namespace _01.Day_of_Week
{
    public class DayOfTheWeek
    {
        public static void Main()
        {
            var dateString = Console.ReadLine();

            var date = DateTime.ParseExact(dateString, "d-M-yyyy", CultureInfo.InvariantCulture);

            Console.WriteLine(date.DayOfWeek);
        }
    }
}
