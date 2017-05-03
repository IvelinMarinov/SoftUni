using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _23._10._2017_4.Roli___The_Coder
{
    public class RoliTheCoder
    {
        public static void Main()
        {
            var line = Console.ReadLine();
            var pattern = @"\w+\s{0,}#\w+(\s{0,}(@[\w']+)){0,}";
            Regex regex = new Regex(pattern);
            var eventsSummary = new List<Event>();

            while (line != "Time for Code")
            {
                if (regex.IsMatch(line))
                {

                    var command = line.Split(new[] { '#', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    var currEventID = command[0];
                    var currEventName = command[1];
                    var currEventParticipants = new List<string>();

                    for (int i = 2; i < command.Length; i++)
                    {
                        if (command[i][0] == '@')
                        {
                            currEventParticipants.Add(command[i]);
                        }
                    }

                    if (!eventsSummary.Any(e => e.ID == currEventID) && !eventsSummary.Any(e => e.Name == currEventName))
                    {
                        var currEvent = new Event()
                        {
                            ID = currEventID,
                            Name = currEventName,
                            Participants = currEventParticipants.Distinct().ToList()
                        };

                        eventsSummary.Add(currEvent);
                    }
                    else if (eventsSummary.Any(e => e.ID == currEventID) && eventsSummary.Any(e => e.Name == currEventName))
                    {
                        var currentEvent = eventsSummary.Where(e => e.Name == currEventName).First();

                        foreach (var participant in currEventParticipants)
                        {
                            if (!currentEvent.Participants.Contains(participant))
                            {
                                currentEvent.Participants.Add(participant);
                            }
                        }
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var item in eventsSummary.OrderByDescending(c => c.NumberOfParticipants).ThenBy(n => n.Name))
            {
                Console.WriteLine($"{item.Name} - {item.NumberOfParticipants}");

                foreach (var participant in item.Participants.OrderBy(n => n).Distinct())
                {
                    Console.WriteLine($"{participant}");
                }
            }
        }
    }
}