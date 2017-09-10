using System;
using System.Linq;

namespace _13._06._2016___02.Jedi_Galaxy
{
    public class JediGalaxy
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = sizes[0];
            var cols = sizes[1];
            var matrix = new int[rows][];
            var numsCounter = 0;
            long starsSum = 0;

            for (int r = 0; r < rows; r++)
            {
                matrix[r] = new int[cols];
                for (int c = 0; c < cols; c++)
                {
                    matrix[r][c] = numsCounter;
                    numsCounter++;
                }
            }

            var ivosPosition = Console.ReadLine();
            var evilsPosition = Console.ReadLine();

            while (ivosPosition != "Let the Force be with you")
            {
                var ivosTokens = ivosPosition
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var irow = ivosTokens[0];
                var icol = ivosTokens[1];
                var imoves = Math.Max(irow, icol);

                var evilsTokens = evilsPosition
                    .Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var erow = evilsTokens[0];
                var ecol = evilsTokens[1];
                var emoves = Math.Max(erow, ecol);

                for (int i = 0; i <= emoves; i++)
                {
                    if(cellIsInsideMatrix(erow - i, ecol - i, rows, cols))
                    {
                        matrix[erow - i][ecol - i] = 0;
                    }
                }

                for (int i = 0; i <= imoves; i++)
                {
                    if (cellIsInsideMatrix(irow - i, icol + i, rows, cols))
                    {
                        starsSum += matrix[irow - i][icol + i];
                    }
                }

                ivosPosition = Console.ReadLine();
                evilsPosition = Console.ReadLine();
            }

            Console.WriteLine(starsSum);
        }
        

        private static bool cellIsInsideMatrix(int newRow, int newCol, int rows, int cols)
        {
            return 0 <= newRow && newRow < rows && 0 <= newCol && newCol < cols;
        }
    }
}
