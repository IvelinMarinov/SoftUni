using System;
using System.Linq;

namespace _05.Compare_Char_Arrays
{
    class CompareCharArrays
    {
        static void Main()
        {
            char[] firstArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
            char[] secondArr = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

            var shorterLenght = Math.Min(firstArr.Length, secondArr.Length);

            for (int i = 0; i < shorterLenght; i++)
            {
                if (firstArr[i] > secondArr[i])
                {
                    Console.WriteLine(string.Join("", secondArr));
                    Console.WriteLine(string.Join("", firstArr));
                    break;
                }
                else if (firstArr[i] < secondArr[i])
                {
                    Console.WriteLine(string.Join("", firstArr));
                    Console.WriteLine(string.Join("", secondArr));
                    break;
                }
                else
                {
                    if (firstArr.Length == shorterLenght && i == shorterLenght - 1)
                    {
                        Console.WriteLine(string.Join("", firstArr));
                        Console.WriteLine(string.Join("", secondArr));
                        break;
                    }
                    else if (secondArr.Length == shorterLenght && i == shorterLenght - 1)
                    {
                        Console.WriteLine(string.Join("", secondArr));
                        Console.WriteLine(string.Join("", firstArr));
                        break;
                    }
                }
            }
        }
    }
}
