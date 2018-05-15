using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Employees.Data;
using Employees.Models.DatabaseModels;
using Employees.Models.DTOs;

namespace Employees.Services
{
    public class EmployeeService
    {
        private readonly EmployeesDbContext context;

        public EmployeeService(EmployeesDbContext context)
        {
            this.context = context; 
        }

        public EmployeeShortDto ById(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            var employeeDto = Mapper.Map<EmployeeShortDto>(employee);

            return employeeDto;
        }

        public void AddEmployee(EmployeeShortDto dto)
        {
            var employee = Mapper.Map<Employee>(dto);

            this.context.Employees.Add(employee);
            this.context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime newBirthday)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id: {employeeId} does not exist");
            }

            employee.Birthday = newBirthday;
            this.context.SaveChanges();
        }

        public void SetAddreess(int employeeId, string newAddress)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id: {employeeId} does not exist");
            }

            employee.Address = newAddress;
            this.context.SaveChanges();
        }

        public EmployeeShortDto GetEmployeeInfo(int employeeId)
        {
            var employee = this.context.Employees
                .FirstOrDefault(e => e.Id == employeeId);
           
            if (employee == null)
            {
                throw new ArgumentException("No such employee");
            }

            var employeeDto = Mapper.Map<EmployeeShortDto>(employee);

            return employeeDto;
        }

        public EmployeeFullDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = this.context.Employees
                .FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                throw new ArgumentException("No such employee");
            }

            var employeeDto = Mapper.Map<EmployeeFullDto>(employee);

            return employeeDto;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Employee with id: {employeeId} does not exist");
            }

            var manager = this.context.Employees.Find(managerId);

            if (manager == null)
            {
                throw new ArgumentException($"Manager with id: {managerId} does not exist");
            }

            employee.ManagerId = managerId;
            this.context.SaveChanges();
        }

        public ManagerDto ManagerInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException($"Manager with id: {employeeId} does not exist");
            }

            var managerDto = Mapper.Map<ManagerDto>(employee);

            return managerDto;
        }

        public IList<EmployeeWithManagerDto> GetEmployeesOverCertainAge(int age)
        {
            if (age < 0)
            {
                throw new ArgumentException("Negative age entered");
            }

            var employeeDtos = this.context.Employees
                .Where(e => DateTime.Now.Year - e.Birthday.Value.Year > age)
                .ProjectTo<EmployeeWithManagerDto>()
                .OrderByDescending(e => e.Salary)
                .ToList();

            return employeeDtos;
        }
    }
}