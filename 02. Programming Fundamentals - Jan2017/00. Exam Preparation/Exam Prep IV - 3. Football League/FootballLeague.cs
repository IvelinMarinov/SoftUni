using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exam_Prep_IV___3.Football_League
{
    public class FootballLeague
    {
        public static void Main()
        {
            var key = Console.ReadLine();
            key = Regex.Escape(key);

            var standings = new Dictionary<string, int>();
            var goalsScored = new Dictionary<string, int>();

            Regex regex = new Regex($@"{key}(.*?){key}.+?{key}(.*?){key}.+?(\d+):(\d+)");

            var gameInfo = Console.ReadLine();

            while (gameInfo != "final")
            {             
                var match = regex.Match(gameInfo);

                var firstTeamString = match.Groups[1].Value.Reverse().ToArray();
                var secondTeamString = match.Groups[2].Value.Reverse().ToArray();
                var firstTeam = new string(firstTeamString).ToUpper();
                var secondTeam = new string(secondTeamString).ToUpper();
                var firstTeamGoals = int.Parse(match.Groups[3].Value);
                var secondTeamGoals = int.Parse(match.Groups[4].Value);

                if (!standings.ContainsKey(firstTeam))
                {
                    standings[firstTeam] = 0;
                }

                if (!standings.ContainsKey(secondTeam))
                {
                    standings[secondTeam] = 0;
                }

                if (!goalsScored.ContainsKey(firstTeam))
                {
                    goalsScored[firstTeam] = 0;
                }

                if (!goalsScored.ContainsKey(secondTeam))
                {
                    goalsScored[secondTeam] = 0;
                }

                goalsScored[firstTeam] += firstTeamGoals;
                goalsScored[secondTeam] += secondTeamGoals;

                if (firstTeamGoals > secondTeamGoals)
                {
                    standings[firstTeam] += 3;
                }
                else if (firstTeamGoals < secondTeamGoals)
                {
                    standings[secondTeam] += 3;
                }
                else
                {
                    standings[firstTeam]++;
                    standings[secondTeam]++;
                }

                gameInfo = Console.ReadLine();
            }

            Console.WriteLine("League standings:");

            var place = 1;

            foreach (var team in standings.OrderByDescending(t => t.Value).ThenBy(t => t.Key))
            {
                Console.WriteLine($"{place}. {team.Key} {team.Value}");
                place++;
            }

            Console.WriteLine("Top 3 scored goals:");

            foreach (var team in goalsScored.OrderByDescending(t => t.Value).ThenBy(t => t.Key).Take(3))
            {
                Console.WriteLine($"- {team.Key} -> {team.Value}");
            }
        }
    }
}