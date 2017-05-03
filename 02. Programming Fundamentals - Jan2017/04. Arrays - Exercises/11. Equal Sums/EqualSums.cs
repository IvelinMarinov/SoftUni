using System;
using System.Linq;

namespace _11.Equal_Sums
{
    class EqualSums
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            int leftCounter = 0;
            int rightCounter = 0;

            bool sumsExist = false;

            if (input.Length == 1 || (input.Length == 2 && input[1] == 0))
            {
                Console.WriteLine("0");
            }
            else if (input.Length == 2 && input[0] == 0)
            {
                Console.WriteLine("1");
            }
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    leftSum += input[i];
                    leftCounter++;

                    for (int j = input.Length - 1; j >= i; j--)
                    {
                        rightSum += input[j];
                        rightCounter++;

                        if (leftSum == rightSum && input.Length == leftCounter + rightCounter + 1)
                        {
                            Console.WriteLine(leftCounter);
                            sumsExist = true;
                            break;
                        }
                        else if (rightSum > leftSum)
                        {
                            break;
                        }

                    }
                    rightSum = 0;
                    rightCounter = 0;

                    if (sumsExist)
                    {
                        break;
                    }
                }
                if (sumsExist == false)
                {
                    Console.WriteLine("no");
                }
            }
        }
    }
}
