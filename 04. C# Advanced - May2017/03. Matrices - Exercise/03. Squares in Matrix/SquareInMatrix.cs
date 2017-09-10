using System;
using System.Linq;

namespace _03.Squares_in_Matrix
{
    public class SquareInMatrix
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matchingSquares = 0;
            var matrix = new string[matrixRows][];

            for (int rowIndex = 0; rowIndex < matrixRows; rowIndex++)
            {
                matrix[rowIndex] = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
            }

            for (int rowIndex = 0; rowIndex < matrix.Length - 1; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length - 1; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == matrix[rowIndex][colIndex + 1] 
                        && matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex] 
                        && matrix[rowIndex][colIndex] == matrix[rowIndex + 1][colIndex + 1])
                    {
                        matchingSquares++;
                    }
                }
            }

            Console.WriteLine(matchingSquares);
        }
    }
}
