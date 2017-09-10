using System;
using System.Collections.Generic;

namespace _05.Filter_By_Age
{
    public class FilterByAge
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var results = new Dictionary<string,int>();
            string[] input;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine()
                    .Split(new string[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                    
                if (!results.ContainsKey(input[0]))
                {
                    results.Add(input[0], int.Parse(input[1]));
                }
            }

            var condition = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            Func<int, bool> tester = CreateTester(condition, age);
            Action<KeyValuePair<string, int>> printer = CreatePrinter(format);

            PrintFilteredResult(results, tester, printer);
        }

        private static void PrintFilteredResult(Dictionary<string, int> results, Func<int, bool> tester, Action<KeyValuePair<string, int>> printer)
        {
            foreach (var entry in results)
            {
                if (tester(entry.Value))
                {
                    printer(entry);
                }
            }
        }

        private static Action<KeyValuePair<string, int>> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name": return p => Console.WriteLine($"{p.Key}");
                case "age": return p => Console.WriteLine($"{p.Value}");
                case "name age": return p => Console.WriteLine($"{p.Key} - {p.Value}");
                default: return null;
            }
        }

        private static Func<int, bool> CreateTester(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x < age;
                case "older": return x => x > age;
                default: return null;
            }
        }
    }
}
