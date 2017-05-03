using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Fold_and_Sum
{
    class FoldAndSum
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            var k = input.Count / 4;

            var firstRowLeft = input
                .Take(k)
                .Reverse();

            var firstRowRight = input
                .Skip(3 * k)
                .Take(k)
                .Reverse();

            var firstRow = firstRowLeft
                .Concat(firstRowRight);

            var secondRow = input
                .Skip(k)
                .Take(2 * k);

            var sum = firstRow.Zip(secondRow, (x, y) => x + y);

            Console.WriteLine(string.Join(" ", sum));    
                
        }
    }
}
