using System;
using System.Collections.Generic;
using System.Globalization;
using Employees.App.Core.Commands.Interfaces;
using Employees.Services;

namespace Employees.App.Core.Commands
{
    public class SetBirthdayCommand : ICommand
    {
        private readonly EmployeeService employeeService;

        public SetBirthdayCommand(EmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        // <employeeId> <date: "dd-MM-yyyy"> 
        public string Execute(IList<string> data)
        {
            var employeeId = int.Parse(data[0]);
            var newBirthDate = DateTime.ParseExact(data[2], "dd-MM-yyyy", CultureInfo.InvariantCulture);

            this.employeeService.SetBirthday(employeeId, newBirthDate);
            
            return "Employee's date of birth successfully updated";
        }
    }
}
