using System;
using System.Collections.Generic;
using System.Linq;

namespace Employees.App.Core
{
    public class Engine
    {
        private readonly IServiceProvider serviceProvider;
        private readonly CommandParser commandParser;

        public Engine(IServiceProvider serviceProvider)
        {
            this.commandParser = new CommandParser();
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    IList<string> commandTokens = input.Split(' ').ToList();
                    string commandName = commandTokens[0];
                    IList<string> commandArgs = commandTokens.Skip(1).ToList();
                    var command = this.commandParser.DispatchCommand(this.serviceProvider, commandName);
                    var result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}