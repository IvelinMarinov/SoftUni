using System;

namespace BusTicketsSystem.Models.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public double Grade { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public DateTime PublishedOn { get; set; }
    }
}
