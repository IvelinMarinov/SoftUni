using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Array_Manipulator
{
    public class ArrayManipulator
    {
        public static List<int> Add(List<int> numbers, List<string> command)
        {
            numbers.Insert(int.Parse(command[1]), int.Parse(command[2]));
            return numbers;
        }

        public static List<int> AddMany(List<int> numbers, List<string> command)
        {
            var NumsToInsert = new List<int>();

            for (int i = 2; i < command.Count; i++)
            {
                NumsToInsert.Add(int.Parse(command[i]));
            }

            numbers.InsertRange(int.Parse(command[1]), NumsToInsert);
            return numbers;
        }

        public static int Contains(List<int> numbers, List<string> command)
        {
            bool isContained = numbers.Contains(int.Parse(command[1]));

            if (isContained)
            {
                return numbers.IndexOf(int.Parse(command[1]));
            }
            else
            {
                return -1;
            }
        }

        public static List<int> Remove(List<int> numbers, List<string> command)
        {
            numbers.RemoveAt(int.Parse(command[1]));
            return numbers;
        }

        public static List<int> Shift(List<int> numbers, List<string> command)
        {
            var rotations = int.Parse(command[1]) % numbers.Count;
            var shiftedNums = new int[numbers.Count];

            for (int i = 0; i < numbers.Count; i++)
            {
                var temp = 0;
                temp = numbers[i];
                shiftedNums[Math.Abs(i + numbers.Count - rotations) % numbers.Count] = temp;
            }
            numbers = shiftedNums.ToList();

            return numbers;
        }

        public static List<int> SumPairs(List<int> numbers, List<string> command)
        {
            var summedPairs = new List<int>();
            var end = 0;

            if (numbers.Count % 2 == 0)
            {
                end = numbers.Count;
            }
            else
            {
                numbers.Add(0);
                end = numbers.Count + 1;
            }

            for (int i = 1; i < end; i = i + 2)
            {
                summedPairs.Add(numbers[i - 1] + numbers[i]);
            }

            numbers = summedPairs;
            return numbers;
        }

        public static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            var command = Console.ReadLine().Split().ToList();

            while (command[0] != "print")
            {
                switch (command[0])
                {
                    case "add":
                        Add(numbers, command);
                        break;
                    case "addMany":
                        AddMany(numbers, command);
                        break;
                    case "contains":
                        Console.WriteLine(Contains(numbers, command));
                        break;
                    case "remove":
                        Remove(numbers, command);
                        break;
                    case "shift":
                        numbers = Shift(numbers, command);
                        break;
                    case "sumPairs":                        
                        numbers = SumPairs(numbers, command);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine($"[{(string.Join(", ", numbers))}]");
        }
    }
}
