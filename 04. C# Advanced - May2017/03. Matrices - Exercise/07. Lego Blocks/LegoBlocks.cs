using System;
using System.Linq;

namespace _07.Lego_Blocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var rows = int.Parse(Console.ReadLine());

            var firstArr = new int[rows][];
            var secondArr = new int[rows][];
            var bothMatch = true;

            for (int i = 0; i < rows; i++)
            {
                firstArr[i] = Console.ReadLine()
                    .Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < rows; i++)
            {
                secondArr[i] = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .Reverse()
                    .ToArray();
            }

            var totalLenght = firstArr[0].Length + secondArr[0].Length;

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                if (firstArr[rowIndex].Length + secondArr[rowIndex].Length != totalLenght)
                {
                    bothMatch = false;
                    break;
                }
            }

            if (bothMatch)
            {
                for (int i = 0; i < rows; i++)
                {
                    Console.WriteLine($"[{string.Join(", ", firstArr[i])}, {string.Join(", ", secondArr[i])}]");
                }
            }
            else
            {
                var totalCells = 0;
                for (int i = 0; i < rows; i++)
                {
                    totalCells += firstArr[i].Length;
                    totalCells += secondArr[i].Length;
                }
                Console.WriteLine($"The total number of cells is: {totalCells}");
            }
        }
    }
}
