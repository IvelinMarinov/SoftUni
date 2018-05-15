using System;
using System.Collections.Generic;
using BusTicketsSystem.App.Core.Commands;

namespace BusTicketsSystem.App.Core
{
    public class CommandParser
    {
        public string DispatchCommand(IList<string> data)
        {
            var commandName = data[0].ToLower();
            var result = string.Empty;

            switch (commandName)
            {
                case "print-info":
                    var printInfoCommand = new PrintInfoCommand();
                    data.RemoveAt(0);
                    result = printInfoCommand.Execute(data);
                    break;
                case "buy-ticket":
                    var buyTicketCommand = new BuyTicketCommand();
                    data.RemoveAt(0);
                    result = buyTicketCommand.Execute(data);
                    break;
                case "publish-review":
                    var publishReviewCommand = new PublishReviewCommand();
                    data.RemoveAt(0);
                    result = publishReviewCommand.Execute(data);
                    break;
                case "print-review":
                    var printReviewCommand = new PrintReviewCommand();
                    data.RemoveAt(0);
                    result = printReviewCommand.Execute(data);
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Invalid Command");

            }

            return result;
        }
    }
}