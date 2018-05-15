using System.Collections.Generic;

namespace BusTicketsSystem.Models.Models
{
    public class BusStation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        public ICollection<Trip> Arrivals { get; set; } = new HashSet<Trip>();

        public ICollection<Trip> Departures { get; set; } = new HashSet<Trip>();
    }
}
