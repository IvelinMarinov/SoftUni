using System;

namespace ConsoleApplication9
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var pattern = Console.ReadLine();

            while (true)
            {

                var lastIndex = input.LastIndexOf(pattern);
                var firstIndex = input.IndexOf(pattern);

                if (firstIndex != -1 && lastIndex != -1 && firstIndex != lastIndex && pattern.Length > 0)
                {
                    Console.WriteLine("Shaked it.");
                    input = input.Remove(firstIndex, pattern.Length);
                    lastIndex = input.LastIndexOf(pattern);
                    input = input.Remove(lastIndex, pattern.Length);
                }

                else
                {
                    Console.WriteLine("No shake.");
                    Console.WriteLine(input);
                    break;
                }

                var indexToRemove = pattern.Length / 2;
                pattern = pattern.Remove(indexToRemove, 1);
            }
        }
    }
}
