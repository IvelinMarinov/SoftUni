using System.Collections.Generic;

namespace BusTicketsSystem.Models.Models
{
    public class Company
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Nationality { get; set; }

        public double Rating { get; set; }

        public ICollection<Review> Reviews { get; set; } = new HashSet<Review>();

        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
