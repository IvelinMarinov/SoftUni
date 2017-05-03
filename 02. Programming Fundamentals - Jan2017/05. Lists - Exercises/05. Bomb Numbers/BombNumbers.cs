using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Bomb_Numbers
{
    public class BombNumbers
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> bombSpecs = Console.ReadLine().Split().Select(int.Parse).ToList();


            var bombNum = bombSpecs[0];
            var bombRange = bombSpecs[1];

            var start = 0;
            var end = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] == bombNum)
                {
                    if (i - bombRange < 0)
                    {
                        start = 0;
                    }
                    else
                    {
                        start = i - bombRange;
                    }

                    if (i + bombRange + 1 > numbers.Count - 1)
                    {
                        end = numbers.Count - 1;
                    }
                    else
                    {
                        end = i + bombRange;
                    }

                    for (int j = start; j <= end; j++)
                    {
                        numbers.RemoveAt(start);
                    }
                    i = -1;
                }
            }
            var sum = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }

            Console.WriteLine(sum);
        }
    }
}
