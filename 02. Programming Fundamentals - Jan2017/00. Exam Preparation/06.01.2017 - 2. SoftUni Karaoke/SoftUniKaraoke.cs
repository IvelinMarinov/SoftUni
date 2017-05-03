using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._01._2017___2.SoftUni_Karaoke
{
    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var separators = new char[] { ',' };

            var participants = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();

            var songs = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => s.Trim())
                .ToList();

            var performance = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(p => p.Trim())
                .ToList();

            var awardWinningPerformers = new List<Participant>();

            while (performance[0] != "dawn")
            {
                var performer = performance[0];
                var songPerformed = performance[1];
                var award = performance[2];

                if (participants.Contains(performer) && songs.Contains(songPerformed))
                {
                    if (!awardWinningPerformers.Any(p => p.Name == performer))
                    {
                        var currentPerformer = new Participant()
                        {
                            Name = performer,
                            Awards = new List<string>()
                        };
                        currentPerformer.Awards.Add(award);
                        awardWinningPerformers.Add(currentPerformer);
                    }
                    else if (awardWinningPerformers.Any(x => x.Name == performer && !awardWinningPerformers.Any(y => y.Awards.Contains(award))))
                    {
                        foreach (var awardWinningPerformer in awardWinningPerformers)
                        {
                            if (awardWinningPerformer.Name == performer)
                            {
                                awardWinningPerformer.Awards.Add(award);
                            }
                        }
                    }
                }

                performance = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            }
            if (awardWinningPerformers.Count == 0)
            {
                Console.WriteLine("No awards");
            }

            foreach (var awardWinningPerformer in awardWinningPerformers.OrderByDescending(x => x.AwardsCount).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{awardWinningPerformer.Name}: {awardWinningPerformer.AwardsCount} awards");

                foreach (var award in awardWinningPerformer.Awards.OrderBy(x => x))
                {
                    Console.WriteLine($"--{award}");
                }
            }
        }
    }
}
