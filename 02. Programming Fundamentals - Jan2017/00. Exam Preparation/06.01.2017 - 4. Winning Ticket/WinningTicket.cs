using System;
using System.Text.RegularExpressions;

namespace _06._01._2017___4.Winning_Ticket
{
    public class WinningTicket
    {
        public static void Main()
        {
            var tickets = Console.ReadLine().Split(new[] { ' ', ',', '\t','\n','\r' }, StringSplitOptions.RemoveEmptyEntries);

            var pattern = @"(\${6,10}|\@{6,10}|\#{6,10}|\^{6,10})";
            Regex regex = new Regex(pattern);

            foreach (var ticket in tickets)
            {
                if (ticket.Length != 20)
                {
                    Console.WriteLine($"invalid ticket");
                }
                else if (ticket == new string('$', 20) ||ticket == new string('@', 20) 
                    || ticket == new string('#', 20) || ticket == new string('^', 20))
                {
                    Console.WriteLine($"ticket \"{ticket}\" - 10{ticket[0]} Jackpot!");
                }
                else
                {
                    var leftSide = ticket.Substring(0, ticket.Length / 2);
                    var rightSide = ticket.Substring(ticket.Length / 2);

                    if (regex.IsMatch(leftSide) && regex.IsMatch(rightSide))
                    {
                        var matchLeft = regex.Match(leftSide);
                        var matchRight = regex.Match(rightSide);
                        var winningSymbolLeft = matchLeft.Groups[1].ToString();
                        var winningSymbolRight = matchRight.Groups[1].ToString();

                        if (winningSymbolLeft[0] == winningSymbolRight[0])
                        {
                            var winningSectionLenght = Math.Min(matchLeft.Length, matchRight.Length);
                            var winningSymbol = matchLeft.Groups[1].ToString();
                            Console.WriteLine($"ticket \"{ticket}\" - {winningSectionLenght}{winningSymbol[0]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"ticket \"{ticket}\" - no match");
                    }
                }                
            }
        }
    }
}
