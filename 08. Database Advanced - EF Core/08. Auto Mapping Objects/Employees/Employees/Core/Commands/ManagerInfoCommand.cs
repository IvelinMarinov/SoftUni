using System.Collections.Generic;
using System.Text;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class ManagerInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public ManagerInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);

            var managerDto = this.employeeService.ManagerInfo(employeeId);

            var sb = new StringBuilder();

            sb.AppendLine(
                $"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.EmployeesManagedCount}");

            foreach (var employee in managerDto.EmployeesManaged)
            {
                sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }
    }
}
