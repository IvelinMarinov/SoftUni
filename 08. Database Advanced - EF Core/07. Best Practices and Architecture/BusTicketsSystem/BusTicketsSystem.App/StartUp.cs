using System;
using System.Collections.Generic;
using BusTicketsSystem.App.Core;
using BusTicketsSystem.Data;
using BusTicketsSystem.Models;
using BusTicketsSystem.Models.Models;

namespace BusTicketsSystem.App
{
    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BusTicketsContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
                SeedDb(db);
            }

            var engine = new Engine();
            engine.Run();
        }

        private static void SeedDb(BusTicketsContext db)
        {
            db.Towns.AddRange(new List<Town>
            {
                new Town { Country = "Bulgaria", Name = "Sofia" },
                new Town { Country = "Bulgaria", Name = "Varna" },
                new Town { Country = "Bulgaria", Name = "Plovdiv" },
                new Town { Country = "Bulgaria", Name = "Ruse" }
            });
            db.SaveChanges();

            db.BusStations.AddRange(new List<BusStation>
            {
                new BusStation { Name = "Central Station", TownId = 1},
                new BusStation { Name = "Union Station", TownId = 2},
                new BusStation { Name = "Northern Station", TownId = 1},
                new BusStation { Name = "Eastern Station", TownId = 3},
            });
            db.SaveChanges();

            db.Companies.AddRange(new List<Company>
            {
                new Company { Name = "SomeCompany", Nationality = "bg", Rating = 6},
                new Company { Name = "SomeCompany2", Nationality = "bg", Rating = 7},
                new Company { Name = "SomeCompany3", Nationality = "bg", Rating = 4}
            });
            db.SaveChanges();

            db.Trips.AddRange(new List<Trip>
            {
                new Trip
                {
                    CompanyId = 1,
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    OriginBusStationId = 1,
                    DestinationBusStationId = 2,
                    Status = TripStatus.Arrived
                },
                new Trip
                {
                    CompanyId = 2,
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    OriginBusStationId = 1,
                    DestinationBusStationId = 3,
                    Status = TripStatus.Cancelled
                },
                new Trip
                {
                    CompanyId = 1,
                    ArrivalTime = DateTime.Now,
                    DepartureTime = DateTime.Now,
                    OriginBusStationId = 4,
                    DestinationBusStationId = 1,
                    Status = TripStatus.Departed
                }
            });
            db.SaveChanges();

            db.Customers.AddRange(new List<Customer>
            {
                new Customer
                {
                    FirstName = "Mickey",
                    LastName = "Mouse",
                    HomeTownId = 1,
                    DateOfBirth = DateTime.MinValue,
                    Gender = Gender.Male
                },
                new Customer
                {
                    FirstName = "Minnie",
                    LastName = "Mouse",
                    HomeTownId = 2,
                    DateOfBirth = DateTime.MinValue,
                    Gender = Gender.Female
                },
                new Customer
                {
                    FirstName = "Donald",
                    LastName = "Duck",
                    HomeTownId = 3,
                    DateOfBirth = DateTime.MinValue,
                    Gender = Gender.Male
                }
            });
            db.SaveChanges();

            db.Tickets.AddRange(new List<Ticket>
            {
                new Ticket{ Price = 20, Seat = "32B", CustomerId = 1, TripId = 2},
                new Ticket{ Price = 50, Seat = "16C", CustomerId = 2, TripId = 1},
                new Ticket{ Price = 32.99m, Seat = "1A", CustomerId = 1, TripId = 3}
            });
            db.SaveChanges();

            db.Reviews.AddRange(new List<Review>
            {
                new Review{ CustomerId = 1, CompanyId = 2, Grade = 8, Content = "Satisfactory", PublishedOn = DateTime.Now},
                new Review{ CustomerId = 2, CompanyId = 1, Grade = 1, Content = "Disgusting", PublishedOn = DateTime.Now},
                new Review{ CustomerId = 1, CompanyId = 3, Grade = 9, Content = "Awesome!", PublishedOn = DateTime.Now},
            });
            db.SaveChanges();

            Console.WriteLine("Database Initialized!");
        }
    }
}
