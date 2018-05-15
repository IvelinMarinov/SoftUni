using System;
using System.Collections.Generic;

namespace BusTicketsSystem.Models.Models
{
    public class Trip
    {
        public int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public TripStatus Status { get; set; }

        public int OriginBusStationId { get; set; }

        public BusStation OriginBusStation { get; set; }

        public int DestinationBusStationId { get; set; }

        public BusStation DestinationBusStation { get; set; }

        public int CompanyId { get; set; }

        public Company Company { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}
