using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonus_Points
{
    class Program
    {
        static void Main(string[] args)
        {
            var points = double.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (points <= 100)
            {
                bonusPoints = bonusPoints + 5;
            }
            if (points > 100 && points <= 1000)
            {
                bonusPoints = 0.2 * points;
            }
            if (points > 1000)
            {
                bonusPoints = 0.1 * points;
            }

            if (points % 2 == 0)
            {
                bonusPoints = bonusPoints + 1;
            }
            if (points % 10 == 5)
            {
                bonusPoints = bonusPoints + 2;
            }
            Console.WriteLine(bonusPoints);
            Console.WriteLine(points + bonusPoints);


  
        }
    }
}
