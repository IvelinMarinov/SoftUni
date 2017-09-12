using System;
using _04.Work_Force.Employees;

namespace _04.Work_Force
{
    public class Job
    {
        public event EventHandler JobDone;

        public Job(string name, int workHoursRequired, Employee employeeAssigned)
        {
            this.Name = name;
            this.WorkHoursRequired = workHoursRequired;
            this.EmployeeAssigned = employeeAssigned;
        }

        public string Name { get; private set; }

        public int WorkHoursRequired { get; private set; }

        public Employee EmployeeAssigned { get; private set; }

        public void Update()
        {
            this.WorkHoursRequired -= this.EmployeeAssigned.WorkHoursPerWeek;
            if (this.WorkHoursRequired <= 0)
            {
                JobDone(this, new EventArgs());
            }
        }

        public void OnJobDone(object sender, EventArgs e)
        {
            Console.WriteLine($"Job {this.Name} done!");
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.WorkHoursRequired}";
        }
    }
}
