using System;

namespace _04.Pascal_Triangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            var height = int.Parse(Console.ReadLine());

            var pascal = new long[height][];
            
            for (int rowIndex = 0; rowIndex < pascal.Length; rowIndex++)
            {
                pascal[rowIndex] = new long[rowIndex + 1];
                pascal[rowIndex][0] = 1;
                pascal[rowIndex][pascal[rowIndex].Length - 1] = 1;

                for (int colIndex = 1; colIndex < pascal[rowIndex].Length - 1; colIndex++)
                {
                    pascal[rowIndex][colIndex] = pascal[rowIndex - 1][colIndex - 1] +
                                                 pascal[rowIndex - 1][colIndex];
                }
            }

            foreach (var row in pascal)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }
    }
}
