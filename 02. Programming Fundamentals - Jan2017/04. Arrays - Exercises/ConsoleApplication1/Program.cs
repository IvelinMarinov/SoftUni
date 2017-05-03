using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        char[] charArr1 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();
        char[] charArr2 = Console.ReadLine().Split(' ').Select(char.Parse).ToArray();

        int length = Math.Min(charArr1.Length, charArr2.Length);

        for (int i = 0; i < length; i++)
        {

            if (charArr1[i] > charArr2[i])
            {
                Console.WriteLine(string.Join("", charArr2));
                Console.WriteLine(string.Join("", charArr1));
                break;
            }
            else if (charArr1[i] < charArr2[i])
            {
                Console.WriteLine(string.Join("", charArr1));
                Console.WriteLine(string.Join("", charArr2));
                break;
            }
            else
            {
                if (length == charArr2.Length && i == length - 1) //дали 2-я е с по-малка д-на от 1-я и е последната проверка
                {
                    Console.WriteLine(string.Join("", charArr2));
                    Console.WriteLine(string.Join("", charArr1));
                }
                else if (length == charArr1.Length && i == length - 1) //дали 1-я е с по-малка д-на от 2-я и е последната проверка
                {
                    Console.WriteLine(string.Join("", charArr1));
                    Console.WriteLine(string.Join("", charArr2));
                }
                else // i != length-1 за случая charArr1[i] = charArr2[i]
                {
                    continue;
                }
            }
        }
    }
}