using System.Collections.Generic;
using Employees.App.Core.Commands.Interfaces;
using Employees.Models.DTOs;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class AddEmployeeCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public AddEmployeeCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <firstName> <lastName> <salary> 
        public string Execute(IList<string> data)
        {
            var firstName = data[0];
            var lastName = data[1];
            var salary = decimal.Parse(data[2]);

            var employeeDto = new EmployeeShortDto
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeService.AddEmployee(employeeDto);

            return $"Employee {firstName} {lastName} successfully added to database";
        }
    }
}
