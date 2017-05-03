using System;
using System.Globalization;

namespace Exam_Preparation_III___1.SoftUni_Coffee_Orders
{
    public class SoftUniCoffeeOrders
    {
        public static void Main()
        {
            var ordersCount = long.Parse(Console.ReadLine());

            var total = 0m;

            for (int i = 0; i < ordersCount; i++)
            {
                var pricePerCapsule = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                var capsulesCount = long.Parse(Console.ReadLine());

                var price = pricePerCapsule * daysInMonth * capsulesCount;

                total += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
