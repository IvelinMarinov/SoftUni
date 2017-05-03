using System;

namespace _01.Day_of_Week
{
    class DayOfWeek
    {
        static void Main()
        {
            var days = new string[7] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            var dayNumber = int.Parse(Console.ReadLine());

            if (dayNumber <= 0 || dayNumber > 7)
            {
                Console.WriteLine("Invalid Day!");
            }

            else
            {
                Console.WriteLine(days[dayNumber - 1]);
            }
        }
    }
}
