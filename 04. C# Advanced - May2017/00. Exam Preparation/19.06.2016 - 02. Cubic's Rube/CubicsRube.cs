using System;
using System.Linq;

namespace _19._06._2016___02.Cubic_s_Rube
{
    public class CubicsRube
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var rube = new long[n][][];

            for (int i = 0; i < n; i++)
            {
                rube[i] = new long[n][];
                for (int j = 0; j < n; j++)
                {
                    rube[i][j] = new long[n];
                }
            }

            int hitCells = 0;
            long sum = 0;
            var input = Console.ReadLine();

            while (input != "Analyze")
            {
                var tokens = input
                    .Split(new[] {' ', '\t', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                long row = tokens[0];
                long col = tokens[1];
                long depth = tokens[2];
                long value = tokens[3];

                if (IsInside(row, col, depth, n) && value > 0)
                {
                    rube[row][col][depth] += value;
                    hitCells++;
                    sum += value;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
            Console.WriteLine(n * n * n - hitCells);
        }

        private static bool IsInside(long row, long col, long depth, long n)
        {
            return 0 <= row && row < n && 0 <= col && col < n && 0 <= depth && depth < n;
        }
    }
}
