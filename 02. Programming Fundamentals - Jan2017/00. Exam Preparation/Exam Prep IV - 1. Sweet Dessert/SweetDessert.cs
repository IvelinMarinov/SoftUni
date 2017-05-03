using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Prep_IV___1.Sweet_Dessert
{
    public class SweetDessert
    {
        public static void Main()
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int guestsCount = int.Parse(Console.ReadLine());
            decimal bananaPricePerUnit = decimal.Parse(Console.ReadLine());
            decimal eggPricePerUnit = decimal.Parse(Console.ReadLine());
            decimal berryPricePerKilo = decimal.Parse(Console.ReadLine());

            var dessertsInSet = 6;
            var neeededSets = guestsCount / dessertsInSet;

            if (guestsCount % dessertsInSet > 0)
            {
                neeededSets++;
            }

            var bananasForOneSet = 2;
            var eggsForOneSet = 4;
            var berriesForOneSet = 0.2m;

            var moneyNeededForOneSet = (bananasForOneSet * bananaPricePerUnit) + 
                (eggsForOneSet * eggPricePerUnit) + (berriesForOneSet * berryPricePerKilo);

            var totalMoneyNeeded = moneyNeededForOneSet * neeededSets;

            if (cash >= totalMoneyNeeded)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {totalMoneyNeeded:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {totalMoneyNeeded - cash:f2}lv more.");
            }
        }
    }
}
