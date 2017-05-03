using System;
using System.Linq;

public class ReverseString
{
    public static void Main()
    {
        int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        int mostFrequentNumbr = 0;
        int repetitions = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            int currentNumber = numbers[i];
            int counter = 0;
            for (int j = i; j < numbers.Length; j++)
            {
                if (currentNumber == numbers[j])
                {
                    counter++;
                }
            }

            if (counter > repetitions)
            {
                mostFrequentNumbr = currentNumber;
                repetitions = counter;
            }
        }

        Console.WriteLine("{0}", mostFrequentNumbr);
    }
}