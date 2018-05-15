using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BusTicketsSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketsSystem.App.Core
{
    public class PrintReviewCommand
    {
        //{Bus Company ID}
        public string Execute(IList<string> data)
        {
            var companyId = int.Parse(data[0]);

            using (var db = new BusTicketsContext())
            {
                if (!db.Companies.Any(c => c.Id == companyId))
                {
                    throw new ArgumentException("No such company");
                }

                var reviews = db.Reviews
                    .AsNoTracking()
                    .Include(r => r.Customer)
                    .Where(r => r.CompanyId == companyId);

                var sb = new StringBuilder();
                foreach (var r in reviews)
                {
                    sb.AppendLine(
                        $"{r.Id} {r.Grade} {r.PublishedOn.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)} " +
                        $"{r.Customer.FirstName} {r.Customer.LastName} {r.Content}");
                }

                return sb.ToString().Trim();
            }
        }
    }
}