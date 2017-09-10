using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Numbers_with_a_Stack
{
    public class ReverseNumbersWithStack
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()                
                .ToArray();

           var stack = new Stack<string>(input);

           for (int i = 0; i < input.Length; i++)
           {
               Console.Write(stack.Pop());

               if (i != input.Length - 1)
               {
                   Console.Write(" ");
               }
           }
           Console.WriteLine();
        }
    }
}
