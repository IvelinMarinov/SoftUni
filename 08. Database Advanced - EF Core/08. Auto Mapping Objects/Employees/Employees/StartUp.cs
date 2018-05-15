using System;
using System.Collections.Generic;
using AutoMapper;
using Employees.Services;
using Employees.App;
using Employees.App.Core;
using Employees.Data;
using Employees.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Employees
{
    public class StartUp
    {
        public static void Main()
        {
            ResetDatabase();

            //AutoMapperConfiguration.InitializeMapper();

            var engine = new Engine(ConfigureServices());
            engine.Run();
        }

        static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<EmployeesDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));

            serviceCollection.AddTransient<EmployeeService>();

            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        private static void ResetDatabase()
        {
            using (var db = new EmployeesDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                SeedDb(db);
                Console.WriteLine("Database Initialized");
            }
        }

        private static void SeedDb(EmployeesDbContext db)
        {
            db.AddRange(new List<Employee>
            {
                new Employee
                {
                    FirstName = "Mickey",
                    LastName = "Mouse",
                    Address = "Disneyland",
                    Salary = 5000,
                    Birthday = new DateTime(1986, 7, 25)
                },
                new Employee
                {
                    FirstName = "Donald",
                    LastName = "Duck",
                    Address = "Disneyland",
                    Salary = 6000,
                    Birthday = new DateTime(1984, 4, 15),
                    ManagerId = 1
                },
                new Employee
                {
                    FirstName = "Minnnie",
                    LastName = "Mouse",
                    Address = "Disneyland",
                    Salary = 15000,
                    Birthday = new DateTime(1986, 1, 1),
                    ManagerId = 1
                },
                new Employee
                {
                    FirstName = "Pluto",
                    LastName = "n/a",
                    Address = "Disneyland",
                    Salary = 1000,
                    Birthday = new DateTime(1987, 10, 10)
                }
            });

            db.SaveChanges();
        }
    }
}
