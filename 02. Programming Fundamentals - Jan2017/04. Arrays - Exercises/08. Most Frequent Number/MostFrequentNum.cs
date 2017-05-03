using System;
using System.Linq;

namespace _08.Most_Frequent_Number
{
    class MostFrequentNum
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int maxFrequentNum = 0;

            int maxCounter = 1;
            for (int i = 0; i < numbers.Length; i++)
            {
                int currentNum = numbers[i];
                int counter = 1;
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        counter++;
                        if (counter > maxCounter)
                        {
                            maxCounter = counter;
                            maxFrequentNum = currentNum;
                        }
                    }
                }
            }
            Console.WriteLine(maxFrequentNum);
        }
    }
}
