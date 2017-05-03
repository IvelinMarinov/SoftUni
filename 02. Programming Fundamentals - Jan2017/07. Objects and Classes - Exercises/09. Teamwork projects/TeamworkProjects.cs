using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Teamwork_projects
{
    public class TeamworkProjects
    {
        public static void Main()
        {
            var numberOfTeams = int.Parse(Console.ReadLine());

            var teamsList = new List<Team>();
            var messages = new List<string>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                var currTeamInfo = Console.ReadLine().Split('-');

                var currTeamCreator = currTeamInfo[0];
                var currTeamName = currTeamInfo[1];

                if (teamsList.Any(x => x.Name == currTeamName))
                {
                    messages.Add($"Team {currTeamName} was already created!");
                }
                else if (teamsList.Any(x => x.Creator == currTeamCreator))
                {
                    messages.Add($"{currTeamCreator} cannot create another team!");
                }
                else
                {
                    var currTeam = new Team
                    {
                        Name = currTeamName,
                        Creator = currTeamCreator,
                        Members = new List<string>()
                    };
                    teamsList.Add(currTeam);
                    messages.Add($"Team {currTeamName} has been created by {currTeamCreator}!");
                }
            }

            var input = Console.ReadLine();

            while (input != "end of assignment")
            {
                var inputArr = input.Split(new char[] { '-', '>' }, StringSplitOptions.RemoveEmptyEntries);
                var teamMemberName = inputArr[0];
                var teamName = inputArr[1];

                if (!teamsList.Any(x => x.Name == teamName))
                {
                    messages.Add($"Team {teamName} does not exist!");
                }
                else if (teamsList.Select(x => x.Members).Any(x => x.Contains(teamMemberName)) || teamsList.Any(x => x.Creator == teamMemberName))
                {
                    messages.Add($"Member {teamMemberName} cannot join team {teamName}!");
                }
                else
                {
                    var currentTeam = teamsList.Where(x => x.Name == teamName).First();
                    currentTeam.Members.Add(teamMemberName);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join("\r\n", messages));

            var teamsToPrint = teamsList.Where(x => x.Members.Count > 0).ToList();

            foreach (var team in teamsToPrint.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine($"{team.Name}");
                Console.WriteLine($"- {team.Creator}");
                Console.WriteLine($"-- {string.Join("\r\n-- ", team.Members.OrderBy(x => x))}");
            }

            var teamsToDisband = teamsList.Where(x => x.Members.Count == 0).ToList();

            Console.WriteLine("Teams to disband:");
            foreach (var team in teamsToDisband.OrderBy(x => x.Name))
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
