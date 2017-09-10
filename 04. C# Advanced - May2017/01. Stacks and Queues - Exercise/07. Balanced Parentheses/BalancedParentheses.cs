using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Balanced_Parentheses
{
    public class BalancedParentheses
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<char>();
            var openingBrackets = new char[] { '{', '[', '(' };
            var isBalanced = true;

            if (input.Length % 2 == 1)
            {
                isBalanced = false;
            }

            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (openingBrackets.Contains(input[i]))
                    {
                        stack.Push(input[i]);
                    }
                    else
                    {
                        switch (input[i])
                        {
                            case '}':
                                if (stack.Pop() != '{')
                                {
                                    isBalanced = false;                                    
                                }
                                break;
                            case ']':
                                if (stack.Pop() != '[')
                                {
                                    isBalanced = false;
                                }
                                break;
                            case ')':
                                if (stack.Pop() != '(')
                                {
                                    isBalanced = false;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }                
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
