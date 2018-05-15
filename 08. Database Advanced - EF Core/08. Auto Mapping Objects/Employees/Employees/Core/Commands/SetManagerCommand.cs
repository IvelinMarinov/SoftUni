using System.Collections.Generic;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class SetManagerCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetManagerCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <managerId> 
        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);
            var managerId = int.Parse(data[1]);

            this.employeeService.SetManager(employeeId, managerId);

            return $"New manager assigned to employee";
        }
    }
}
