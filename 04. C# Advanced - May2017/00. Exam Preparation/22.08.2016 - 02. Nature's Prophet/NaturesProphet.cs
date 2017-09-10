using System;
using System.Linq;

namespace _22._08._2016___02.Nature_s_Prophet
{
    public class NaturesProphet
    {
        public static void Main()
        {
            var sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rowsNumber = sizes[0];
            var colsNumber = sizes[1];

            var matrix = new int[rowsNumber][];

            for (int i = 0; i < rowsNumber; i++)
            {
                matrix[i] = new int[colsNumber];
            }

            var input = Console.ReadLine();

            while (input != "Bloom Bloom Plow")
            {
                var flowerCoordinates = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var row = flowerCoordinates[0];
                var col = flowerCoordinates[1];

                for (int i = 0; i < colsNumber; i++)
                {
                    matrix[row][i]++;
                }

                for (int i = 0; i < rowsNumber; i++)
                {
                    matrix[i][col]++;
                }

                input = Console.ReadLine();

                matrix[row][col]--;
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
