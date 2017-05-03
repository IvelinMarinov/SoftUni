using System;
using System.Collections.Generic;
using System.Globalization;

namespace _01.Count_Work_Days
{
    public class CountWorkDays
    {
        public static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            var endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var officialHolidays = new List<DateTime>();
                        
            for (var i = startDate.Year; i <= endDate.Year; i++)
            {
                officialHolidays.Add(new DateTime(i, 01, 01));
                officialHolidays.Add(new DateTime(i, 03, 03));
                officialHolidays.Add(new DateTime(i, 05, 01));
                officialHolidays.Add(new DateTime(i, 05, 06));
                officialHolidays.Add(new DateTime(i, 05, 24));
                officialHolidays.Add(new DateTime(i, 09, 06));
                officialHolidays.Add(new DateTime(i, 09, 22));
                officialHolidays.Add(new DateTime(i, 11, 01));
                officialHolidays.Add(new DateTime(i, 12, 24));
                officialHolidays.Add(new DateTime(i, 12, 25));
                officialHolidays.Add(new DateTime(i, 12, 26));
            }

            var workingDays = 0;

            for (var i = startDate; i <= endDate; i = i.AddDays(1))
            {
                if (i.DayOfWeek != DayOfWeek.Saturday && i.DayOfWeek != DayOfWeek.Sunday && !officialHolidays.Contains(i))
                {
                    workingDays++;
                }
            }

            Console.WriteLine(workingDays);
        }

    }
}