using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Sets_Of_Elements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var nCount = input[0];
            var mCount = input[1];

            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            int num;

            for (int i = 0; i < nCount; i++)
            {
                num = int.Parse(Console.ReadLine());
                nSet.Add(num);
            }

            for (int i = 0; i < mCount; i++)
            {
                num = int.Parse(Console.ReadLine());
                mSet.Add(num);
            }

            if (mSet.Count >= nSet.Count)
            {
                foreach (var number in mSet)
                {
                    if (nSet.Contains(number))
                    {
                        Console.WriteLine(number);
                    }
                }
            }
            else
            {
                foreach (var number in nSet)
                {
                    if (mSet.Contains(number))
                    {
                        Console.WriteLine(number);
                    }
                }
            }
        }
    }
}
