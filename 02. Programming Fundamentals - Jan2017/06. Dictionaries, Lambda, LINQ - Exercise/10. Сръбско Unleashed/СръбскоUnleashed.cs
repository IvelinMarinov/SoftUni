using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _10.Сръбско_Unleashed
{
    public class СръбскоUnleashed
    {
        public static void Main(string[] args)
        {
            string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            var inputString = Console.ReadLine();

            var summary = new Dictionary<string, Dictionary<string, int>>();

            while (inputString != "End")
            {
                if (!Regex.IsMatch(inputString, pattern))
                {
                    inputString = Console.ReadLine();
                    continue;
                }
                var input = inputString.Split('@').ToList();
                var singer = input[0].Trim();
                var remainingInput = input[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();                
                var ticketPrice = int.Parse(remainingInput[remainingInput.Count - 2]);
                var ticketsCount = int.Parse(remainingInput[remainingInput.Count - 1]);
                var venue = string.Empty;

                for (int i = 0; i < remainingInput.Count - 2; i++)
                {
                    venue += remainingInput[i] + " ";
                }

                venue = venue.Trim();


                if (!summary.ContainsKey(venue))
                {
                    summary[venue] = new Dictionary<string, int>();
                }

                if (!summary[venue].ContainsKey(singer))
                {
                    summary[venue][singer] = ticketPrice * ticketsCount;
                }
                else
                {
                    summary[venue][singer] += ticketPrice * ticketsCount;
                }

                inputString = Console.ReadLine();
            }

            foreach (KeyValuePair<string, Dictionary<string, int>> venue in summary)
            {
                Console.WriteLine($"{venue.Key}");

                foreach (KeyValuePair<string, int> concert in venue.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {concert.Key} -> {concert.Value}");
                }
            }
        }
    }
}
