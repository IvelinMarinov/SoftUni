using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BePositive_broken
{
    public static void Main()
    {
        int countSequences = int.Parse(Console.ReadLine());

        for (int i = 0; i < countSequences; i++)
        {
            var input = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            input.Add(-1);

            bool found = false;

            var result = new StringBuilder();

            for (int j = 0; j < input.Count - 1; j++)
            {
                int currentNum = input[j];

                if (currentNum >= 0)
                {
                    result.Append(currentNum + " ");
                    found = true;
                }
                else
                {
                    currentNum += input[j + 1];

                    if (currentNum >= 0)
                    {
                        result.Append(currentNum + " ");
                        found = true;
                        j += 1;
                    }
                    else
                    {
                        j += 1;
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(result.ToString().Trim());
            }
            else
            {
                Console.WriteLine("(empty)");
            }
        }
    }
}