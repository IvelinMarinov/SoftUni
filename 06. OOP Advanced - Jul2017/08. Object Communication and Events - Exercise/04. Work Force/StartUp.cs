
using System;
using System.Collections.Generic;
using System.Linq;
using _04.Work_Force.Employees;

namespace _04.Work_Force
{
    public class StartUp
    {
        public static void Main()
        {
            List<Job> jobs = new List<Job>();
            List<Employee> employees = new List<Employee>();

            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                switch (input[0])
                {
                    case "Job":
                        Job currJob = new Job(input[1], int.Parse(input[2]), employees.FirstOrDefault(e => e.Name == input[3]));
                        currJob.JobDone += currJob.OnJobDone;
                        jobs.Add(currJob);
                        break;
                    case "StandartEmployee":
                        employees.Add(new StandartEmployee(input[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(input[1]));
                        break;
                    case "Pass":
                        foreach (var job in jobs.Where(j => j.WorkHoursRequired > 0))
                        {
                            job.Update();
                        }
                        break;
                    case "Status":
                        foreach (var job in jobs.Where(j => j.WorkHoursRequired > 0))
                        {
                            Console.WriteLine(job.ToString());
                        }
                        break;
                }

                input = Console.ReadLine().Split();
            }
        }
    }
}
