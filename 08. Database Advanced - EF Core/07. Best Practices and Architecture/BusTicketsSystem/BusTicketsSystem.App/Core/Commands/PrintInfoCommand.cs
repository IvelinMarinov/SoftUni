using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using BusTicketsSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace BusTicketsSystem.App.Core.Commands
{
    public class PrintInfoCommand
    {
        //{Bus Station ID}
        public string Execute(IList<string> data)
        {
            var busStationId = int.Parse(data[0]);

            using (var db = new BusTicketsContext())
            {
                var busStation = db.BusStations
                    .AsNoTracking()
                    .Where(bs => bs.Id == busStationId)
                    .Select(bs => new
                    {
                        Name = bs.Name,
                        TownName = bs.Town.Name,
                        Arrivals = bs.Arrivals.Select(a => new
                        {
                            DestinationBusStation = a.DestinationBusStation.Name,
                            OriginBusStation = a.OriginBusStation.Name,
                            ArrivalTime = a.ArrivalTime,
                            Status = a.Status
                        }).ToList(),
                        Departures = bs.Departures.Select(d => new
                        {
                            DestinationBusStation = d.DestinationBusStation.Name,
                            OriginBusStation = d.OriginBusStation.Name,
                            DepartureTime = d.DepartureTime,
                            Status = d.Status
                        }).ToList(),

                    })
                    .FirstOrDefault();



                if (busStation == null)
                {
                    throw new ArgumentException("Invalid bus station");
                }

                var sb = new StringBuilder();
                sb.AppendLine($"{busStation.Name}, {busStation.TownName}");
                sb.AppendLine("Arrivals:");
                if (busStation.Arrivals.Count > 0)
                {
                    foreach (var trip in busStation.Arrivals)
                    {
                        sb.AppendLine(
                            $"From {trip.OriginBusStation} | Arrive at: {trip.ArrivalTime} | Status: {trip.Status}");
                    }
                }
                else
                {
                    sb.AppendLine("n/a");
                }

                sb.AppendLine($"Departures:");
                if (busStation.Departures.Count > 0)
                {
                    foreach (var trip in busStation.Departures)
                    {
                        sb.AppendLine(
                            $"To {trip.DestinationBusStation} | Depart at: " +
                            $"{trip.DepartureTime.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)} " +
                            $"| Status {trip.Status}");
                    }
                }
                else
                {
                    sb.AppendLine("n/a");
                }

                return sb.ToString().Trim();
            }
        }
    }
}
