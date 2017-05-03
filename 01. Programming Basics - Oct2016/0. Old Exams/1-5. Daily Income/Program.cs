using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.Daily_Income
{
    class Program
    {
        static void Main(string[] args)
        {
            var workingDaysPerMonth = int.Parse(Console.ReadLine());
            var dailyIncome = double.Parse(Console.ReadLine());
            var Xrate = double.Parse(Console.ReadLine());

            var monthlyIncome = workingDaysPerMonth * dailyIncome;
            var annualIncome = monthlyIncome * 14.5;
            var netAnnualIncome = annualIncome * 0.75;
            var netDailyIncome = netAnnualIncome / 365;
            var netDailyIncomeBGN = netDailyIncome * Xrate;

            Console.WriteLine(Math.Round(netDailyIncomeBGN, 2));

        }
    }
}
