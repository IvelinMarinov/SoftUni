using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Football_Team_Generator
{
    public class StartUp
    {
        public static void Main()
        {
            var teams = new List<Team>();
            var input = Console.ReadLine();
            string teamName;
            string playerName;
            double endurance;
            double sprint;
            double dribble;
            double passing;
            double shooting;
            Team team;
            Player player;

            while (input != "END")
            {
                var tokens = input.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];


                switch (command)
                {
                    case "Team":
                        teamName = tokens[1];
                        if (!teams.Any(t => t.Name == teamName))
                        {
                            teams.Add(new Team(teamName));
                        }
                        break;

                    case "Add":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        endurance = double.Parse(tokens[3]);
                        sprint = double.Parse(tokens[4]);
                        dribble = double.Parse(tokens[5]);
                        passing = double.Parse(tokens[6]);
                        shooting = double.Parse(tokens[7]);

                        if (teams.Any(t => t.Name == teamName))
                        {
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            try
                            {
                                player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.Players.Add(player);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;

                    case "Remove":
                        teamName = tokens[1];
                        playerName = tokens[2];
                        if (teams.Any(t => t.Name == teamName))
                        {
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            if (team.Players.Any(p => p.Name == playerName))
                            {
                                player = team.Players.FirstOrDefault(p => p.Name == playerName);
                                team.Players.Remove(player);
                            }
                            else
                            {
                                Console.WriteLine($"Player {playerName} is not in {teamName} team. ");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;

                    case "Rating":
                        teamName = tokens[1];
                        if (teams.Any(t => t.Name == teamName))
                        {
                            team = teams.FirstOrDefault(t => t.Name == teamName);
                            Console.WriteLine($"{team.Name} - {team.CalculateRating()}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                        break;
                }
                input = Console.ReadLine();
            }
        }
    }
}
