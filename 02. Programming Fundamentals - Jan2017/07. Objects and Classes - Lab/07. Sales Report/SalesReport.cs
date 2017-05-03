using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Sales_Report
{
    public class SalesReport
    {
        public static Sale ReadSale()
        {
            var saleInfo = Console.ReadLine().Split();

            var newSale = new Sale()
            {
                City = saleInfo[0],
                Product = saleInfo[1],
                Price = double.Parse(saleInfo[2]),
                Quantity = double.Parse(saleInfo[3])                
            };

            return newSale;
        }

        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var salesList = new List<Sale>();

            for (int i = 0; i < n; i++)
            {
                salesList.Add(ReadSale());
            }

            var result = new SortedDictionary<string, double>();

            foreach (var sale in salesList)
            {
                if (!result.ContainsKey(sale.City))
                {
                    result[sale.City] = 0.0;
                }

                result[sale.City] += sale.Revenue;
            }

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key:f2} -> {item.Value:f2}");
            }
        }
    }
}
