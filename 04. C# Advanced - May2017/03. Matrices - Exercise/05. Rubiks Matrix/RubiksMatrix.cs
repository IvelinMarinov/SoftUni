using System;
using System.Linq;

namespace _05.Rubiks_Matrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            var matrixSizes = Console.ReadLine()
                .Split(new char[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrixRows = matrixSizes[0];
            var matrixCols = matrixSizes[1];
            var number = 1;
            var matrix = new int[matrixRows][];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {   
                matrix[rowIndex] = new int[matrixCols];

                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    matrix[rowIndex][colIndex] = number;
                    number++;
                } 
            }

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine()
                    .Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var colOrRowIndex = int.Parse(command[0]);
                var moves = int.Parse(command[2]);

                switch (command[1])
                {
                    case "up":
                        MoveCol(matrix, colOrRowIndex, moves);
                        break;
                    case "down":
                        MoveCol(matrix, colOrRowIndex, matrix.Length - moves % matrix.Length);
                        break;
                    case "left":
                        MoveRow(matrix, colOrRowIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix,colOrRowIndex, matrix[0].Length - moves % matrix[0].Length);
                        break;
                    default:
                        break;
                }
            }
            int element = 1;

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                {
                    if (matrix[rowIndex][colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.Length; r++)
                        {
                            for (int c = 0; c < matrix[r].Length; c++)
                            {
                                if (matrix[r][c] == element)
                                {
                                    var currNum = matrix[rowIndex][colIndex];
                                    matrix[rowIndex][colIndex] = element;
                                    matrix[r][c] = currNum;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }

                    element++;
                }
            }
        }

        private static void MoveRow(int[][] matrix, int colOrRowIndex, int moves)
        {
            var rotatedArr = new int[matrix[0].Length];

            for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
            {
                rotatedArr[colIndex] = matrix[colOrRowIndex][(colIndex + moves) % matrix[0].Length];
            }
            matrix[colOrRowIndex] = rotatedArr;
        }

        private static void MoveCol(int[][] matrix, int colOrRowIndex, int timesToRotate)
        {
            var rotatedArr = new int[matrix.Length];

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                rotatedArr[rowIndex] = matrix[(rowIndex + timesToRotate) % matrix.Length][colOrRowIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                matrix[rowIndex][colOrRowIndex] = rotatedArr[rowIndex];
            }
        }
    }
}
