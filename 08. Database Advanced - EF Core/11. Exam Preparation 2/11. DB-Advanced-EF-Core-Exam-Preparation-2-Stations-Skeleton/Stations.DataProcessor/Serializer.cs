using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto;
using Stations.Models;
using Formatting = Newtonsoft.Json.Formatting;

namespace Stations.DataProcessor
{
    public class Serializer
    {
        public static string ExportDelayedTrains(StationsDbContext context, string dateAsString)
        {
            var date = DateTime.ParseExact(dateAsString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            var trains = context.Trains
                .Where(t => t.Trips.Any(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date))
                .Select(t => new
                {
                    t.TrainNumber,
                    DelayedTrips = t.Trips
                        .Where(tr => tr.Status == TripStatus.Delayed && tr.DepartureTime <= date)
                        .ToArray()
                })
                .Select(t => new TrainExportDto
                {
                    TrainNumber = t.TrainNumber,
                    DelayedTimes = t.DelayedTrips.Length,
                    MaxDelayedTime = t.DelayedTrips.Max(tr => tr.TimeDifference).ToString()
                })
                .OrderByDescending(t => t.DelayedTimes)
                .ThenByDescending(t => t.MaxDelayedTime)
                .ThenBy(t => t.TrainNumber)
                .ToArray();

            var json = JsonConvert.SerializeObject(trains, Formatting.Indented);
            return json;
        }

        public static string ExportCardsTicket(StationsDbContext context, string cardType)
        {
            var cardTypeEnum = Enum.Parse<CardType>(cardType, true);

            var cards = context.Cards
                .Where(c => c.Type == cardTypeEnum && c.BoughtTickets.Any())
                .Select(c => new CardExportDto
                {
                    Name = c.Name,
                    Type = c.Type.ToString(),
                    TicketsBought = c.BoughtTickets.Select(bt => new TicketExportDto
                    {
                        DestinationStation = bt.Trip.DestinationStation.Name,
                        OriginStation = bt.Trip.OriginStation.Name,
                        DepartureTime = bt.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)
                    }).ToArray()
                })
                .OrderBy(c => c.Name)
                .ToArray();

            var doc = new XDocument();
            doc.Add(new XElement("Cards"));

            foreach (var card in cards)
            {
                var cardEl = new XElement("Card");
                cardEl.Add(new XAttribute("name", card.Name));
                cardEl.Add(new XAttribute("type", card.Type));
                cardEl.Add(new XElement("Tickets"));

                foreach (var ticket in card.TicketsBought)
                {
                    var ticketEl = new XElement("Ticket");
                    ticketEl.Add(new XElement("OriginStation", ticket.OriginStation));
                    ticketEl.Add(new XElement("DestinationStation", ticket.DestinationStation));
                    ticketEl.Add(new XElement("DepartureTime", ticket.DepartureTime));
                    cardEl.Element("Tickets").Add(ticketEl);
                }

                doc.Root.Add(cardEl);
            }

            var result = doc.ToString();
            return result;
        }
    }
}