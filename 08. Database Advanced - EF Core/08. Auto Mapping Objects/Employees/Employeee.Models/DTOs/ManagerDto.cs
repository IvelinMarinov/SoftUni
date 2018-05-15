using System.Collections.Generic;
using Employees.Models.DatabaseModels;

namespace Employees.Models.DTOs
{
    public class ManagerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Employee> EmployeesManaged { get; set; } = new List<Employee>();

        public int EmployeesManagedCount { get; set; }
    }
}
