using System;
using System.Linq;

namespace _06.Target_Practise
{
    public class TargetPractise
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matrixCols = matrixSizes[1];
            var matrix = new Char[matrixRows][];

            var snake = Console.ReadLine();
            
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex] = new char[matrixCols];
            }

            var charCounter = 0;
            for (int i = matrix.Length - 1; i >= 0; i--)
            {
                for (int j = matrix[i].Length - 1; j >= 0; j--)
                {
                    if (charCounter > snake.Length - 1)
                    {
                        charCounter = 0;
                    }

                    matrix[i][j] = snake[charCounter];
                    charCounter++;
                }
            }

            for (int i = matrix.Length - 2; i >= 0 ; i = i -2)
            {
                var tempArr = matrix[i].Reverse().ToArray();
                matrix[i] = tempArr;
            }

            var shotParams = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var impactRow = shotParams[0];
            var impactCol = shotParams[1];
            var radius = shotParams[2];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (isCellWithinImpactRadius(rowIndex, colIndex, impactRow, impactCol, radius))
                    {
                        matrix[rowIndex][colIndex] = ' ';
                    }
                }
            }

            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                for (int rowIndex = matrix.Length - 1; rowIndex >= 1; rowIndex--)
                {
                    if (matrix[rowIndex][colIndex] == ' ' && matrix[rowIndex - 1][colIndex] != ' ')
                    {
                        while (rowIndex < matrix.Length)
                        {
                            if (matrix[rowIndex][colIndex] == ' ')
                            {
                                var temp = matrix[rowIndex - 1][colIndex];
                                matrix[rowIndex - 1][colIndex] = matrix[rowIndex][colIndex];
                                matrix[rowIndex][colIndex] = temp;
                            }
                            rowIndex++;
                        }
                    }
                }
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        public static bool isCellWithinImpactRadius(int rowIndex, int colIndex, int impactRow, int impactCol, int radius)
        {
            var distance = Math.Sqrt(Math.Pow((rowIndex - impactRow), 2) + Math.Pow((colIndex - impactCol), 2));
            return distance <= radius;
        }
    }
}
