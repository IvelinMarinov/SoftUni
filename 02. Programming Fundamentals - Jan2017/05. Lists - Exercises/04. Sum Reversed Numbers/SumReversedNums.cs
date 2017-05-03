using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.Sum_Reversed_Numbers
{
    public class SumReversedNums
    {
        public static void Main()
        {
            List<string> numbers = Console.ReadLine().Split().ToList();

            var sum = 0;
         
            foreach (var number in numbers)
            {
                char[] temp = number.ToCharArray();
                Array.Reverse(temp);

                var reversedString = new string(temp);
                var reversedInt = int.Parse(reversedString);
                sum += reversedInt;

            }
            Console.WriteLine(sum);            
        }
    }
}
