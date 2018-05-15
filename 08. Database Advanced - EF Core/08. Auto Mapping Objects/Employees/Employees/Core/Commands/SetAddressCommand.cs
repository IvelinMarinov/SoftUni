using System.Collections.Generic;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class SetAddressCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetAddressCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <address> 
        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);
            var newAddress = data[1];

            this.employeeService.SetAddreess(employeeId, newAddress);
            
            return "Employee's address successfully updated";
        }
    }
}
