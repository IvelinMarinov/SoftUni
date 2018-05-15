using System;
using System.Text;

public class Worker : Human
{
    private decimal weeklySalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, decimal weeeklySalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeeklySalary = weeeklySalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public override string LastName
    {
        get
        {
            if (base.LastName.Length < 4)
            {
                throw new ArgumentException("Expected length more than 3 symbols! Argument: lastName");
            }
            return base.LastName;
        }
    }

    public double WorkHoursPerDay
    {
        get { return this.workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            this.workHoursPerDay = value;
        }
    }

    public decimal WeeklySalary
    {
        get { return this.weeklySalary; }
        set
        {
            if (value < 10)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            this.weeklySalary = value;
        }
    }

    public decimal CalculateSalaryPerHour()
    {
        return this.weeklySalary / (decimal)this.workHoursPerDay / 5;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"First Name: {this.FirstName}")
        .AppendLine($"Last Name: {this.LastName}")
        .AppendLine($"Week Salary: {this.WeeklySalary:f2}")
        .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
        .AppendLine($"Salary per hour: {this.CalculateSalaryPerHour():f2}");
        return sb.ToString();
    }
}