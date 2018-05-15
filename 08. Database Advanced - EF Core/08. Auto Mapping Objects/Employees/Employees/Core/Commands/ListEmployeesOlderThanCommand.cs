using System.Collections.Generic;
using System.Text;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ListEmployeesOlderThanCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <age>
        public string Execute(IList<string> data)
        {
            var age = int.Parse(data[0]);

            var employees = this.employeeService.GetEmployeesOverCertainAge(age);

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine(
                    $"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - Manager: {employee.ManagerLastName ?? "[no manager]"}");

            }

            return sb.ToString().Trim();
        }
    }
}
