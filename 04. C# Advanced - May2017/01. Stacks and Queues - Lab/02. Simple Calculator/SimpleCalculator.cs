using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Simple_Calculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(' ');

            var stack = new Stack<string>(input.Reverse());
            
            while (stack.Count > 1)
            {
                var firstNum = int.Parse(stack.Pop());
                var oper = stack.Pop();
                var secondNum = int.Parse(stack.Pop());

                var result = 0;

                if (oper == "+")
                {
                    result = firstNum + secondNum;
                }
                else
                {
                    result = firstNum - secondNum;       
                }

                stack.Push(result.ToString());
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
