﻿namespace _04.Work_Force.Employees
{
    public class PartTimeEmployee : Employee
    {
        private const int WorkHoursPerWeek = 20;

        public PartTimeEmployee(string name) 
            : base(name, WorkHoursPerWeek)
        {
        }
    }
}
