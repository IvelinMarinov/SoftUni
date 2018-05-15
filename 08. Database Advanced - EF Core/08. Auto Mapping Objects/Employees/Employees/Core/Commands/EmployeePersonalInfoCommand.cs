using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public EmployeePersonalInfoCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);

            var employeeDto = this.employeeService.GetEmployeePersonalInfo(employeeId);

            var sb = new StringBuilder();

            sb.AppendLine(
                $"ID: {employeeDto.Id} - {employeeDto.FirstName} {employeeDto.LastName} - ${employeeDto.Salary:f2}");

            if (employeeDto.Birthday.HasValue)
            {
                sb.AppendLine(
                    $"Birthday: {employeeDto.Birthday.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)}");
            }
            else
            {
                sb.AppendLine(
                    $"Birthday: n/a");
            }

            sb.AppendLine($"Address: {employeeDto.Address ?? "n/a"}");

            return sb.ToString().Trim();
        }
    }
}
