using System;
using System.Collections.Generic;

namespace _09.Stack_Fibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var prevNum = stack.Pop();
                var currNum = prevNum + stack.Peek();
                stack.Push(prevNum);
                stack.Push(currNum);
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
