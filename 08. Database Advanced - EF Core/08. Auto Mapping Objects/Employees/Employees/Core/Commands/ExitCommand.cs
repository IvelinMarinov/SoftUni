using System;
using System.Collections.Generic;
using Employees.App.Core.Commands.Interfaces;

namespace Employees.App.Core.Commands
{
    public class ExitCommand : ICommand
    {
        public string Execute(IList<string> data)
        {
            Console.WriteLine("Goodbye!");
            Environment.Exit(0);

            return string.Empty;
        }
    }
}
