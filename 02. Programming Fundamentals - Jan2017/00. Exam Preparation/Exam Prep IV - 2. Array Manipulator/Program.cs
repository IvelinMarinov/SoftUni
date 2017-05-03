using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam_Prep_IV___4.Array_Manipulator
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToList();

            var command = Console.ReadLine()
                .Split()
                .ToList();

            while (command[0] != "end")
            {
                switch (command[0])
                {
                    case "exchange":
                        var exchangeIndex = int.Parse(command[1]);

                        if (exchangeIndex < 0 || exchangeIndex >= input.Count)
                        {
                            Console.WriteLine("Invalid index");
                            break;
                        }
                        else
                        {
                            input = Exchange(input, exchangeIndex);
                        }
                        break;

                    case "max":
                        switch (command[1])
                        {
                            case "odd":
                                var maxOdd = MaxOdd(input);

                                if (maxOdd != -1)
                                {
                                    Console.WriteLine(maxOdd);
                                }
                                else
                                {
                                    Console.WriteLine($"No matches");
                                }
                                break;

                            case "even":
                                var maxEven = MaxEven(input);

                                if (maxEven != -1)
                                {
                                    Console.WriteLine(maxEven);
                                }
                                else
                                {
                                    Console.WriteLine($"No matches");
                                }
                                break;
                            default:
                                break;
                        }
                        break;

                    case "min":
                        switch (command[1])
                        {
                            case "odd":
                                var minOdd = MinOdd(input);

                                if (minOdd != -1)
                                {
                                    Console.WriteLine(minOdd);
                                }
                                else
                                {
                                    Console.WriteLine($"No matches");
                                }
                                break;

                            case "even":
                                var minEven = MinEven(input);

                                if (minEven != -1)
                                {
                                    Console.WriteLine(minEven);
                                }
                                else
                                {
                                    Console.WriteLine($"No matches");
                                }
                                break;
                            default:
                                break;
                        }
                        break;

                    case "first":
                        switch (command[2])
                        {
                            case "even":
                                var firstEvenCount = int.Parse(command[1]);

                                if (firstEvenCount <= input.Count)
                                {
                                    var firstEven = FirstEven(input, firstEvenCount);
                                    Console.WriteLine($"[{string.Join(", ", firstEven)}]");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid count");
                                }
                                break;
                            case "odd":
                                var firstOddCount = int.Parse(command[1]);

                                if (firstOddCount <= input.Count)
                                {
                                    var firstOdd = FirstOdd(input, firstOddCount);
                                    Console.WriteLine($"[{string.Join(", ", firstOdd)}]");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid count");
                                }
                                break;
                            default:
                                break;
                        }
                        break;

                    case "last":
                        switch (command[2])
                        {
                            case "even":
                                var lastEvenCount = int.Parse(command[1]);

                                if (lastEvenCount <= input.Count)
                                {
                                    var lastEven = LastEven(input, lastEvenCount);
                                    Console.WriteLine($"[{string.Join(", ", lastEven)}]");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid count");
                                }
                                break;
                            case "odd":
                                var lastOddCount = int.Parse(command[1]);

                                if (lastOddCount <= input.Count)
                                {
                                    var lastOdd = LastOdd(input, lastOddCount);
                                    Console.WriteLine($"[{string.Join(", ", lastOdd)}]");
                                }
                                else
                                {
                                    Console.WriteLine("Invalid count");
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split()
                .ToList();
            }
            Console.WriteLine($"[{string.Join(", ", input)}]");
        }        

        public static List<int> Exchange(List<int> input, int exchangeIndex)
        {
            var start = input.Take(exchangeIndex + 1).ToList();
            var end = input.Skip(exchangeIndex + 1).Take(input.Count - exchangeIndex - 1).ToList();
            var exchangedInput = new List<int>();
            exchangedInput.AddRange(end);
            exchangedInput.AddRange(start);
            return exchangedInput;
        }

        public static int MaxOdd(List<int> input)
        {
            var currOdd = 0;
            var maxOdd = int.MinValue;
            var maxIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 1)
                {
                    currOdd = input[i];

                    if (currOdd >= maxOdd)
                    {
                        maxOdd = currOdd;
                        maxIndex = i;
                    }
                }
            }

            if (maxOdd != int.MinValue)
            {
                return maxIndex;
            }
            else
            {
                return -1;
            }            
        }

        public static int MaxEven(List<int> input)
        {
            var currEven = 0;
            var maxEven = int.MinValue;
            var maxIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    currEven = input[i];

                    if (currEven >= maxEven)
                    {
                        maxEven = currEven;
                        maxIndex = i;
                    }
                }
            }

            if (maxEven != int.MinValue)
            {
                return maxIndex;
            }
            else
            {
                return -1;
            }
        }

        private static int MinOdd(List<int> input)
        {
            var currOdd = 0;
            var minOdd = int.MaxValue;
            var minIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 1)
                {
                    currOdd = input[i];

                    if (currOdd <= minOdd)
                    {
                        minOdd = currOdd;
                        minIndex = i;
                    }
                }
            }

            if (minOdd != int.MaxValue)
            {
                return minIndex;
            }
            else
            {
                return -1;
            }
        }

        private static int MinEven(List<int> input)
        {
            var currEven = 0;
            var minEven = int.MaxValue;
            var minIndex = 0;

            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] % 2 == 0)
                {
                    currEven = input[i];

                    if (currEven <= minEven)
                    {
                        minEven = currEven;
                        minIndex = i;
                    }
                }
            }

            if (minEven != int.MaxValue)
            {
                return minIndex;
            }
            else
            {
                return -1;
            }
        }

        private static List<int> FirstEven(List<int> input, int firstEvenCount)
        {
            var Even = input.Where(x => x % 2 == 0);
            return Even.Take(firstEvenCount).ToList();
        }

        private static List<int> FirstOdd(List<int> input, int firstOddCount)
        {
            var Even = input.Where(x => x % 2 == 1);
            return Even.Take(firstOddCount).ToList();
        }

        private static List<int> LastEven(List<int> input, int lastEvenCount)
        {
            var Even = input.Where(x => x % 2 == 0).Reverse();
            return Even.Take(lastEvenCount).Reverse().ToList();
        }

        private static List<int> LastOdd(List<int> input, int lastOddCount)
        {
            var Odd = input.Where(x => x % 2 == 1).Reverse();
            return Odd.Take(lastOddCount).Reverse().ToList();
        }
    }
}
