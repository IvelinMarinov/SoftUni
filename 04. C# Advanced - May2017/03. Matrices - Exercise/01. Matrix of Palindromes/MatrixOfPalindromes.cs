using System;
using System.Linq;

namespace _01.Matrix_of_Palindromes
{
    public class MatrixOfPalindromes
    {
        public const string alphabetString = "abcdefghijklmnopqrstuvwxyz";

        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matrixCols = matrixSizes[1];
            char[] alphabet = alphabetString.ToCharArray();

            var matrix = new string[matrixRows][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new string[matrixCols];

                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = $"{alphabet[rowIndex]}{alphabet[rowIndex + colIndex]}{alphabet[rowIndex]}";
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
