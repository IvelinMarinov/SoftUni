using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation_III___2.Command_Interpreter
{
    public class CommandInterpreter
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var commandArr = command
                    .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                switch (commandArr[0])
                {
                    case "reverse":
                        var reverseStart = int.Parse(commandArr[2]);
                        var reverseCount = int.Parse(commandArr[4]);

                        if (IsValidInput(input, reverseStart, reverseCount))
                        {
                            Reverse(input, reverseStart, reverseCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;

                    case "sort":
                        var sortStart = int.Parse(commandArr[2]);
                        var sortCount = int.Parse(commandArr[4]);

                        if (IsValidInput(input, sortStart, sortCount))
                        {
                            Sort(input, sortStart, sortCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;

                    case "rollLeft":
                        var rollLeftCount = int.Parse(commandArr[1]);

                        if (rollLeftCount >= 0)
                        {
                            input = RollLeft(input, rollLeftCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;

                    case "rollRight":
                        var rollRightCount = int.Parse(commandArr[1]);

                        if (rollRightCount >= 0)
                        {
                            input = RollRight(input, rollRightCount);
                        }
                        else
                        {
                            Console.WriteLine($"Invalid input parameters.");
                        }
                        break;
                }
                command = Console.ReadLine();
            }
            var inputString = string.Join(", ", input);

            Console.WriteLine($"[{inputString}]");
        }

        public static void Reverse(List<string> input, int start, int count)
        {
            input.Reverse(start, count);
            //var beginning = input.Take(start).ToList();
            //var reversed = input.Skip(start).Take(count).Reverse().ToList();
            //var end = input.Skip(start + count).Take(input.Count - start - count).ToList();
            //var reversedInput = new List<string>();
            //reversedInput.AddRange(beginning);
            //reversedInput.AddRange(reversed);
            //reversedInput.AddRange(end);
            //input = reversedInput;
        }

        public static void Sort(List<string> input, int start, int count)
        {
            input.Sort(start, count, StringComparer.InvariantCulture);
            //var beginning = input.Take(start).ToList();
            //var sorted = input.Skip(start).Take(count).OrderBy(x => x).ToList();
            //var end = input.Skip(start + count).Take(input.Count - start - count).ToList();
            //var sortedInput = new List<string>();
            //sortedInput.AddRange(beginning);
            //sortedInput.AddRange(sorted);
            //sortedInput.AddRange(end);
            //input = sortedInput;
        }

        public static List<string> RollLeft(List<string> input, int count)
        {
            var rolledInput = new string[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                rolledInput[Math.Abs(i + input.Count - count) % input.Count] = input[i];
            }

            return rolledInput.ToList();
        }

        public static List<string> RollRight(List<string> input, int count)
        {
            var rolledInput = new string[input.Count];
            for (int i = 0; i < input.Count; i++)
            {
                rolledInput[Math.Abs(i + input.Count + count) % input.Count] = input[i];
            }

            return rolledInput.ToList();
        }

        public static bool IsValidInput(List<string> input, int start, int count)
        {
            if (start >= 0 && start < input.Count && count >= 0 && (start + count) <= input.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
