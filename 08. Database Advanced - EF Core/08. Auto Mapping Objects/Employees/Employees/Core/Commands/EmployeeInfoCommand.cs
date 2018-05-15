using System.Collections.Generic;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class EmployeeInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeeInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId>
        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);

            var employeeDto = this.employeeService.GetEmployeeInfo(employeeId);

            return
                $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName}-  ${employeeDto.Salary:f2}";
        }
    }
}
