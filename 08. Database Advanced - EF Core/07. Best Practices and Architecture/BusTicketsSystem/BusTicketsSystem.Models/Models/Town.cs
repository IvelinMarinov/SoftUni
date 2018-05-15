using System.Collections.Generic;

namespace BusTicketsSystem.Models.Models
{
    public class Town
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<Customer> Customers { get; set; } = new HashSet<Customer>();

        public ICollection<BusStation> BusStations { get; set; } = new HashSet<BusStation>();
    }
}
 