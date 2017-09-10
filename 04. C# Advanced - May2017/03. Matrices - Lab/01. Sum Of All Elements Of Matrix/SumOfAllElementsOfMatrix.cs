using System;
using System.Linq;

namespace _01.Sum_Of_All_Elements_Of_Matrix
{
    public class SumOfAllElementsOfMatrix
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matrix = new int[matrixRows][];
            var sum = 0;

            for (int row = 0; row < matrixRows; row++)
            {
                var currArr = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currArr;

                sum += matrix[row].Sum();
            }

            Console.WriteLine(matrix.Length);
            Console.WriteLine(matrix[matrixRows - 1].Length);
            Console.WriteLine(sum);
        }
    }
}
