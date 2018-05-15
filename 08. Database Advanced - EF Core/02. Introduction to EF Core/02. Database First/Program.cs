using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    public class Program
    {
        public const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public static void Main()
        {
            var db = new SoftUniContext();

            #region 03. Employees Full Information

            var employees = db.Employees
                .OrderBy(e => e.EmployeeId)
                .ToList();

            using (StreamWriter writer = new StreamWriter("ResultFiles/03.txt"))
            {
                foreach (var e in employees)
                {
                    writer.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
                }
            }

            #endregion

            #region 04. Employees with Salary Over 50 000

            var employeesWithSalaryOver50k = db.Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => e.FirstName);

            File.WriteAllLines("ResultFiles/04.txt", employeesWithSalaryOver50k);

            #endregion

            #region 05. Employees from Research and Development

            var employeesFromRnD = db.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Department = e.Department.Name,
                    Salary = e.Salary
                });

            var result = new List<string>();

            foreach (var e in employeesFromRnD)
            {
                result.Add($"{e.FirstName} {e.LastName} from {e.Department} - ${e.Salary:f2}");
            }

            File.WriteAllLines("ResultFiles/05.txt", result);

            #endregion

            #region 06. Adding a New Address and Updating Employee

            var employeeToAssignAddress = db.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            var employeesLists = new List<Employee>();
            employeesLists.Add(employeeToAssignAddress);

            db.Addresses.Add(new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
                Employees = new List<Employee>(employeesLists)
            });

            db.SaveChanges();

            var employeeAddresses = db.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText);

            File.WriteAllLines("ResultFiles/06.txt", employeeAddresses);

            #endregion

            #region 07. Employees and Projects

            var employeesWithProjects = db.Employees
                .Include(e => e.Manager)
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .Where(e => e.EmployeesProjects.Any(p =>
                    p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(30)
                .ToList();

            using (StreamWriter writer = new StreamWriter("ResultFiles/07.txt"))
            {
                foreach (var e in employeesWithProjects)
                {
                    string managerFirstName;
                    string managerLastName;

                    managerFirstName = e.Manager == null ? "" : e.Manager.FirstName;
                    managerLastName = e.Manager == null ? "" : e.Manager.LastName;

                    writer.WriteLine($"{e.FirstName} {e.LastName} - Manager: {managerFirstName} {managerLastName}");

                    foreach (var p in e.EmployeesProjects)
                    {
                        string startDate = p.Project.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture);
                        string endDate;

                        endDate = p.Project.EndDate == null ? "not finished" : p.Project.EndDate.Value.ToString(DateFormat, CultureInfo.InvariantCulture);
                        writer.WriteLine($"--{p.Project.Name} - {startDate} - {endDate}");
                    }
                }
            }

            #endregion

            #region 08. Addresses by Town

            var addressesWithEmployees = db.Addresses.OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    AddressText = a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .ToList();

            using (StreamWriter writer = new StreamWriter("ResultFiles/08.txt"))
            {
                foreach (var address in addressesWithEmployees)
                {
                    writer.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeesCount} employees");
                }
            }

            #endregion

            #region 09. Employee 147

            var employee147 = db.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(ep => ep.Project)
                .SingleOrDefault(e => e.EmployeeId == 147);

            using (StreamWriter writer = new StreamWriter("ResultFiles/09.txt"))
            {
                writer.WriteLine($"{employee147.FirstName} {employee147.LastName} - {employee147.JobTitle}");

                foreach (var project in employee147.EmployeesProjects.OrderBy(ep => ep.Project.Name))
                {
                    writer.WriteLine($"{project.Project.Name}");
                }
            }


            #endregion

            #region 10. Departments with More Than 5 Employees

            var departments = db.Departments
                .Include(d => d.Manager)
                .Include(d => d.Employees)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name);

            using (StreamWriter writer = new StreamWriter("ResultFiles/10.txt"))
            {
                foreach (var department in departments)
                {
                    writer.WriteLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                    foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                    {
                        writer.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                    }

                    writer.WriteLine("----------");
                }
            }

            #endregion

            #region 11. Find Latest 10 Projects

            var lastStartedProjects = db.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name);

            using (StreamWriter writer = new StreamWriter("ResultFiles/11.txt"))
            {
                foreach (var project in lastStartedProjects)
                {
                    writer.WriteLine($"{project.Name}");
                    writer.WriteLine($"{project.Description}");
                    writer.WriteLine($"{project.StartDate.ToString(DateFormat, CultureInfo.InvariantCulture)}");
                }
            }

            #endregion

            #region 12. Increase Salaries

            string[] departmentsForRaise = new[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesForRaise = db.Employees
                .Where(e => departmentsForRaise.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            foreach (var employee in employeesForRaise)
            {
                employee.Salary *= 1.12m;
            }

            db.SaveChanges();

            using (StreamWriter writer = new StreamWriter("ResultFiles/12.txt"))
            {
                foreach (var employee in employeesForRaise)
                {
                    writer.WriteLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
                }
            }

            #endregion

            #region 13. Find Employees by First Name Starting With Sa

            var employeesStartingWithSa = db.Employees
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName);

            using (StreamWriter writer = new StreamWriter("ResultFiles/13.txt"))
            {
                foreach (var employee in employeesStartingWithSa)
                {
                    writer.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
                }
            }

            #endregion

            #region 14. Delete Project by Id

            var projectToRemove = db.Projects.Find(2);
            var epToRemove = db.EmployeesProjects
                .Where(e => e.ProjectId == 2)
                .ToList();

            db.EmployeesProjects.RemoveRange(epToRemove);
            db.SaveChanges();

            db.Projects.Remove(projectToRemove);
            db.SaveChanges();

            var projectsToPrint = db.Projects
                .Take(10)
                .ToList()
                .Select(p => p.Name);

            File.WriteAllLines("ResultFiles/14.txt", projectsToPrint);

           #endregion
        }
    }
}
