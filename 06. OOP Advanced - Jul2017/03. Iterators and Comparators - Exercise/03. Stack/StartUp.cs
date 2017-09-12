using System;
using System.Linq;

namespace _03.Stack
{
    public class StartUp
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            var command = Console.ReadLine()
                .Split(new []{",", " "},StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (command[0] != "END")
            {
                switch (command[0])
                {
                    case "Push":
                        command.RemoveAt(0);
                        foreach (var element in command)
                        {
                            stack.Push(element);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (ArgumentException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }

                command = Console.ReadLine()
                    .Split(new[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
            }

            foreach (var element in stack.Reverse())
            {
                Console.WriteLine(element);
            }

            foreach (var element in stack.Reverse())
            {
                Console.WriteLine(element);
            }
        }
    }
}
