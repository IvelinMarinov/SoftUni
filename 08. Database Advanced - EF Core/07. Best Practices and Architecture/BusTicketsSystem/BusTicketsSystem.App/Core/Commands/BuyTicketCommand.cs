using System;
using System.Collections.Generic;
using System.Linq;
using BusTicketsSystem.Data;
using BusTicketsSystem.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace BusTicketsSystem.App.Core.Commands
{
    public class BuyTicketCommand
    {
        //{customer ID} {Trip ID} {Price} {Seat}
        public string Execute(IList<string> data)
        {
            var customerId = int.Parse(data[0]);
            var tripId = int.Parse(data[1]);
            var price = decimal.Parse(data[2]);
            var seat = data[3];

            using (var db = new BusTicketsContext())
            {
                var customer = db.Customers
                    .AsNoTracking()
                    .FirstOrDefault(c => c.Id == customerId);

                if (customer == null)
                {
                    throw new ArgumentException("No such customer");
                }

                if (!db.Trips.Any(t => t.Id == tripId))
                {
                    throw new ArgumentException("No such trip");
                }

                db.Tickets.Add(new Ticket
                {
                    CustomerId = customerId,
                    TripId = tripId,
                    Price = price,
                    Seat = seat
                });
                db.SaveChanges();

                return
                    $"Customer {customer.FirstName} {customer.LastName} bought ticket " +
                    $"for trip {tripId} for {price} on seat {seat}";
            }
        }
    }
}
