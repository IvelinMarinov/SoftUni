using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._11._16_mor_6.Battles
{
    class Program
    {
        static void Main(string[] args)
        {
            var numFirstPlayer = int.Parse(Console.ReadLine());
            var numSecondPlayer = int.Parse(Console.ReadLine());
            var maxBattles = int.Parse(Console.ReadLine());
            bool flag = false;

            for (int i = 1; i <= numFirstPlayer; i++)
            {
                for (int j = 1; j <= numSecondPlayer; j++)
                {
                    Console.Write("({0} <-> {1}) ", i, j);
                    maxBattles--;

                    if (maxBattles == 0)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    break;
                }
            }
            Console.WriteLine();

        }
    }
}
