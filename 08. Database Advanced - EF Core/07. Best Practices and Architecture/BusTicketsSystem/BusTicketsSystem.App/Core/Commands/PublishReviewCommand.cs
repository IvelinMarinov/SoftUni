using System;
using System.Collections.Generic;
using System.Linq;
using BusTicketsSystem.Data;
using BusTicketsSystem.Models.Models;

namespace BusTicketsSystem.App.Core.Commands
{
    public class PublishReviewCommand
    {
        // {Customer ID} {Grade} {Bus Company Name} {Content}
        public string Execute(IList<string> data)
        {
            var customerId = int.Parse(data[0]);
            var grade = double.Parse(data[1]);
            var busCompanyName = data[2];
            var content = data[3];

            using (var db = new BusTicketsContext())
            {
                var customer = db.Customers
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.FirstName + " " + c.LastName
                    })
                    .FirstOrDefault(c => c.Id == customerId);

                if (customer == null)
                {
                    throw new ArgumentException("No such customer");
                }

                var company = db.Companies
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.Name
                    })
                    .FirstOrDefault(c => c.Name == busCompanyName);

                if (company == null)
                {
                    throw new ArgumentException("No such company");
                }

                db.Reviews.Add(new Review
                {
                    CompanyId = company.Id,
                    CustomerId = customer.Id,
                    Content = content,
                    Grade = grade
                });
                db.SaveChanges();

                return $"Customer {customer.Name} published review for company {company.Name}";
            }

            
        }
    }
}
