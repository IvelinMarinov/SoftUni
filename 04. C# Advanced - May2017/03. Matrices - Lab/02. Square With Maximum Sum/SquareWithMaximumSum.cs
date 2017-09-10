using System;
using System.Linq;

namespace _02.Square_With_Maximum_Sum
{
    public class SquareWithMaximumSum
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matrixColumns = matrixSizes[1];
            var maxSum = int.MinValue;
            var matrix = new int[matrixRows][];
            var maxSquare = new int[2][];

            for (int row = 0; row < matrixRows; row++)
            {
                var currArr = Console.ReadLine()
                    .Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                matrix[row] = currArr;
            }

            for (int row = 0; row < matrix.Length - 1; row++)
            {
                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    var sum = matrix[row][col] + matrix[row][col + 1] + 
                        matrix[row + 1][col] + matrix[row + 1][col + 1];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        maxSquare[0] = new int[2];
                        maxSquare[1] = new int[2];
                        maxSquare[0][0] = matrix[row][col];
                        maxSquare[0][1] = matrix[row][col + 1];
                        maxSquare[1][0] = matrix[row + 1][col];
                        maxSquare[1][1] = matrix[row + 1][col + 1];
                    }
                }
            }

            Console.WriteLine(string.Join(" ", maxSquare[0]));
            Console.WriteLine(string.Join(" ", maxSquare[1]));
            Console.WriteLine(maxSum);
        }
    }
}
