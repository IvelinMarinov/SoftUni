using System;
using System.Linq;

namespace _04.Maximal_Sum
{
    public class MaximalSum
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var maxSum = int.MinValue;
            var maxMatrix = new int[3][];
            maxMatrix[0] = new int[3];
            maxMatrix[1] = new int[3];
            maxMatrix[2] = new int[3];

            var matrix = new int[matrixRows][];

            for (int i = 0; i < matrixRows; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int rowIndex = 0; rowIndex < matrix.Length - 2; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 2; colIndex++)
                {
                    var currSum = matrix[rowIndex][colIndex] + matrix[rowIndex][colIndex + 1] + matrix[rowIndex][colIndex + 2] +
                                  matrix[rowIndex + 1][colIndex] + matrix[rowIndex + 1][colIndex + 1] + matrix[rowIndex + 1][colIndex + 2] +
                                  matrix[rowIndex + 2][colIndex] + matrix[rowIndex + 2][colIndex + 1] + matrix[rowIndex + 2][colIndex + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;

                        maxMatrix[0][0] = matrix[rowIndex][colIndex];
                        maxMatrix[0][1] = matrix[rowIndex][colIndex + 1];
                        maxMatrix[0][2] = matrix[rowIndex][colIndex + 2];
                        maxMatrix[1][0] = matrix[rowIndex + 1][colIndex];
                        maxMatrix[1][1] = matrix[rowIndex + 1][colIndex + 1];
                        maxMatrix[1][2] = matrix[rowIndex + 1][colIndex + 2];
                        maxMatrix[2][0] = matrix[rowIndex + 2][colIndex];
                        maxMatrix[2][1] = matrix[rowIndex + 2][colIndex + 1];
                        maxMatrix[2][2] = matrix[rowIndex + 2][colIndex + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            foreach (var row in maxMatrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
