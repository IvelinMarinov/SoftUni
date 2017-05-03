using System;
using System.Linq;

namespace _04.Tripple_Sum
{
    class TripleSum
    {
        static void Main()
        {
            string input = Console.ReadLine();

            var inputArr = input.Split(' ');
            var inputInt = new int[inputArr.Length];

            for (int i = 0; i < inputArr.Length; i++)
            {
                var currentText = inputArr[i];
                var currentInt = int.Parse(currentText);
                inputInt[i] = currentInt;
            }

            int counter = 0;

            for (int a = 0; a < inputInt.Length - 1; a++)
            {
                for (int b = a + 1; b < inputInt.Length; b++)
                {
                    for (int c = 0; c < inputInt.Length; c++)
                    {
                        if (inputInt[a] + inputInt[b] == inputInt[c])
                        {
                            Console.WriteLine($"{inputInt[a]} + {inputInt[b]} == {inputInt[c]}");
                            counter++;
                        }
                    }
                }
            }
            if (counter == 0)
            {
                Console.WriteLine("No");
            }                      
        }
    }
}

