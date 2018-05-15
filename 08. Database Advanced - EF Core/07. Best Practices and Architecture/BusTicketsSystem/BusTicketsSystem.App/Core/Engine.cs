using System;
using System.Collections.Generic;
using System.Linq;

namespace BusTicketsSystem.App.Core
{
    public class Engine
    {
        private readonly CommandParser commandDispatcher;

        public Engine()
        {
            this.commandDispatcher = new CommandParser();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine().Trim();
                    List<string> data = input.Split(' ').ToList();
                    string result = this.commandDispatcher.DispatchCommand(data);
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
