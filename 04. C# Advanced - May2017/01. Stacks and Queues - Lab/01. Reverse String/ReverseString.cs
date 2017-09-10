using System;
using System.Collections.Generic;

namespace _01.Reverse_String
{
    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var stack = new Stack<char>(input.Length);
            
            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            for (int i = 0; i < input.Length; i++)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
