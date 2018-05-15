using System;
using System.Linq;
using System.Reflection;
using Employees.App.Core.Commands.Interfaces;

namespace Employees.App.Core
{
    public class CommandParser
    {
        public ICommand DispatchCommand(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                .ToArray();

            var commandType = commandTypes
                .SingleOrDefault(t => t.Name == $"{commandName}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }

            var constructor = commandType.GetConstructors()
                .FirstOrDefault();

            var constructorParams = constructor.GetParameters()
                .Select(pi => pi.ParameterType);

            var constructorArgs = constructorParams.Select(serviceProvider.GetService)
                .ToArray();

            var command = (ICommand)constructor.Invoke(constructorArgs);

            return command;
        }

        //public string DispatchCommand(IList<string> commandParameters)
        //{
        //    var commandName = commandParameters[0].ToLower();
        //    var result = string.Empty;

        //    switch (commandName)
        //    {
        //        case "addemployee":
        //            var addEmployeeCmd = new AddEmployeeCommand();
        //            commandParameters.RemoveAt(0);
        //            result = addEmployeeCmd.Execute(commandParameters);
        //            break;
        //        case "setbirthday":
        //            var setBirthdayCmd = new SetBirthdayCommand();
        //            commandParameters.RemoveAt(0);
        //            result = setBirthdayCmd.Execute(commandParameters);
        //            break;
        //        case "setaddress":
        //            var setAddressCmd = new SetAddressCommand();
        //            commandParameters.RemoveAt(0);
        //            result = setAddressCmd.Execute(commandParameters);
        //            break;
        //        case "employeeinfo":
        //            var employeeInfoCmd = new EmployeeInfoCommand();
        //            commandParameters.RemoveAt(0);
        //            result = employeeInfoCmd.Execute(commandParameters);
        //            break;
        //        case "employeepersonalinfo":
        //            var employeePersonalInfoCmd = new EmployeePersonalInfoCommand();
        //            commandParameters.RemoveAt(0);
        //            result = employeePersonalInfoCmd.Execute(commandParameters);
        //            break;
        //        case "exit":
        //            var exitCmd = new ExitCommand();
        //            exitCmd.Execute();
        //            break;
        //        case "setmanager":
        //            var setManagerCmd = new SetManagerCommand();
        //            commandParameters.RemoveAt(0);
        //            result = setManagerCmd.Execute(commandParameters);
        //        default:
        //            throw new ArgumentException("Invalid Command");
        //    }

        //    return result;
        //}
    }
}