using System;

namespace _02.Knight_Game
{
    public class KnightGame
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            for (int i = 0; i < matrix.Length; i++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                matrix[i] = new char[n];
                matrix[i] = inputRow;
            }

            var currentKnightsInDanger = 0;
            var maxKnightsInDanger = int.MinValue;
            var mostEndangeredKnightRow = 0;
            var mostEndangeredKnightCol = 0;
            var count = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix[rowIndex].Length; colIndex++)
                    {
                        if (matrix[rowIndex][colIndex].Equals('K'))
                        {
                            // vertical up and left
                            if (IsCellInMatrix(rowIndex - 2, colIndex - 1, matrix))
                            {
                                if (matrix[rowIndex - 2][colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical up and right
                            if (IsCellInMatrix(rowIndex - 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex - 2][colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical down and left
                            if (IsCellInMatrix(rowIndex + 2, colIndex - 1, matrix))
                            {
                                if (matrix[rowIndex + 2][colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical down and right
                            if (IsCellInMatrix(rowIndex + 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex + 2][colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and left
                            if (IsCellInMatrix(rowIndex - 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex - 1][colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and right
                            if (IsCellInMatrix(rowIndex - 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex - 1][colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and left
                            if (IsCellInMatrix(rowIndex + 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex + 1][colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and right
                            if (IsCellInMatrix(rowIndex + 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex + 1][colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostEndangeredKnightRow = rowIndex;
                            mostEndangeredKnightCol = colIndex;
                        }
                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostEndangeredKnightRow][mostEndangeredKnightCol] = 'O';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        public static bool IsCellInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}