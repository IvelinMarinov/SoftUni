using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new [] {' ', '\t', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var columns = sizes[1];
            var counter = 1;

            var matrix = new List<List<int>>(rows);

            for (int r = 0; r < rows; r++)
            {
                matrix.Add(new List<int>());
                for (int c = 0; c < columns; c++)
                {
                    matrix[r].Add(counter);
                    counter++;
                }
            }

            var input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                var inputArr = input
                    .Split(new [] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int impactRow = inputArr[0];
                int impactCol = inputArr[1];
                var impactRadius = inputArr[2];

                if (CellIsInsideMatrix(impactRow, impactCol, matrix))
                {
                    matrix[impactRow][impactCol] = 0;
                }

                for (int i = 0; i <= impactRadius; i++)
                {
                    if (CellIsInsideMatrix(impactRow + i, impactCol, matrix))
                    {
                        matrix[impactRow + i][impactCol] = 0;
                    }
                    if (CellIsInsideMatrix(impactRow - i, impactCol, matrix))
                    {
                        matrix[impactRow - i][impactCol] = 0;
                    }
                    if (CellIsInsideMatrix(impactRow, impactCol + i, matrix))
                    {
                        matrix[impactRow][impactCol + i] = 0;
                    }
                    if (CellIsInsideMatrix(impactRow, impactCol - i, matrix))
                    {
                        matrix[impactRow][impactCol - i] = 0;
                    }
                }

                for (int r = matrix.Count - 1; r >= 0; r--)
                {
                    for (int c = matrix[r].Count - 1; c >= 0 ; c--)
                    {
                        if (matrix[r][c] == 0)
                        {
                            matrix[r].RemoveAt(c);
                        }
                    }

                    if (matrix[r].Count == 0)
                    {
                        matrix.RemoveAt(r);
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool CellIsInsideMatrix(int row, int col, List<List<int>> matrix)
        {
            return (row < matrix.Count && row >= 0 && col < matrix[row].Count && col >= 0);
        }
    }
}
