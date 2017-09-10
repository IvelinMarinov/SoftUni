using System;
using System.Linq;

namespace _2.Diagonal_Difference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var matrix = new long[n][];
            long primaryDiagonal = 0;
            long secondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                matrix[i] = Console.ReadLine()
                    .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                primaryDiagonal += matrix[rowIndex][rowIndex];
                secondaryDiagonal += matrix[rowIndex][matrix.Length - 1 - rowIndex];
            }

            var diagonalDifference = Math.Abs(primaryDiagonal - secondaryDiagonal);

            Console.WriteLine(diagonalDifference);
        }
    }
}
