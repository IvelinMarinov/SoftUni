using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Money
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitCoins = int.Parse(Console.ReadLine());
            var CHY = int.Parse(Console.ReadLine());
            var comission = double.Parse(Console.ReadLine());

            var bitCoinsToBGN = bitCoins * 1168;
            var bitCoinsToEUR = bitCoinsToBGN / 1.95;

            var CHYToUSD = CHY * 0.15;
            var CHYToBGN = CHYToUSD * 1.76;
            var totalMoney = bitCoinsToEUR + CHYToEUR;
            
            var totalComission = totalMoney * comission / 100;
            var CHYToEUR = CHYToBGN / 1.95;
            var PeshosBudget = totalMoney - totalComission;
            Console.WriteLine(PeshosBudget);
        }
    }
}
