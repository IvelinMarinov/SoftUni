using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using AutoMapper;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto;
using Stations.Models;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {
            var stationDtos = JsonConvert.DeserializeObject<List<StationImportDto>>(jsonString);
            var sb = new StringBuilder();
            var stationsToAdd = new List<Station>();

            foreach (var stationDto in stationDtos)
            {
                if (!IsValid(stationDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (stationDto.Town == null)
                {
                    stationDto.Town = stationDto.Name;
                }

                if (stationsToAdd.Any(s => s.Name == stationDto.Name))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var station = Mapper.Map<Station>(stationDto);
                stationsToAdd.Add(station);
                sb.AppendLine(String.Format(SuccessMessage, station.Name));
            }

            context.Stations.AddRange(stationsToAdd);
            context.SaveChanges();

            var result = sb.ToString().Trim();
            return result;
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var seatingClassDtos = JsonConvert.DeserializeObject<List<SeatingClassImportDto>>(jsonString);
            var sb = new StringBuilder();
            var seatingClassesToAdd = new List<SeatingClass>();

            foreach (var seatingClassDto in seatingClassDtos)
            {
                if (!IsValid(seatingClassDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (seatingClassesToAdd.Any(sc => sc.Name == seatingClassDto.Name ||
                                            sc.Abbreviation == seatingClassDto.Abbreviation))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClass = Mapper.Map<SeatingClass>(seatingClassDto);
                seatingClassesToAdd.Add(seatingClass);
                sb.AppendLine(string.Format(SuccessMessage, seatingClass.Name));
            }

            context.SeatingClasses.AddRange(seatingClassesToAdd);
            context.SaveChanges();

            var result = sb.ToString().Trim();
            return result;
        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var deserializedTrains = JsonConvert.DeserializeObject<TrainImportDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
            var sb = new StringBuilder();
            var validTrains = new List<Train>();

            foreach (var trainDto in deserializedTrains)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainAlreadyExists = validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber);
                if (trainAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatsAreValid = trainDto.Seats.All(IsValid);
                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClassesAreValid = trainDto.Seats
                    .All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && 
                         sc.Abbreviation == s.Abbreviation));
                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.Parse<TrainType>(trainDto.Type);

                var trainSeats = trainDto.Seats.Select(s => new TrainSeat
                {
                    SeatingClass = context.SeatingClasses
                    .SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                .ToArray();

                var train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);

                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var tripDtos = JsonConvert.DeserializeObject<List<TripImportDto>>(jsonString);
            var sb = new StringBuilder();
            var tripsToAdd = new List<Trip>();

            foreach (var tripDto in tripDtos)
            {
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var train = context.Trains.SingleOrDefault(t => t.TrainNumber == tripDto.Train);
                var originStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.OriginStation);
                var destinationStation = context.Stations.SingleOrDefault(s => s.Name == tripDto.DestinationStation);

                if (train == null || originStation == null || destinationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var arrivalTime =
                    DateTime.ParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                var departureTime =
                    DateTime.ParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

                if (arrivalTime < departureTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                TimeSpan? timeDifference = null;

                if (tripDto.TimeDifference != null)
                {
                    timeDifference =
                        TimeSpan.ParseExact(tripDto.TimeDifference, "hh\\:mm", CultureInfo.InvariantCulture);
                }

                TripStatus tripStatus;
                var parseResult = Enum.TryParse(tripDto.Status, true, out tripStatus);

                if (!parseResult)
                {
                    tripStatus = TripStatus.OnTime;
                }

                var trip = new Trip()
                {
                    Train = train,
                    DestinationStation = destinationStation,
                    OriginStation = originStation,
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    TimeDifference = timeDifference,
                    Status = tripStatus 
                };

                tripsToAdd.Add(trip);
                sb.AppendLine($"Trip from {tripDto.OriginStation} to {tripDto.DestinationStation} imported.");
            }

            context.Trips.AddRange(tripsToAdd);
            context.SaveChanges();

            var result = sb.ToString().Trim();
            return result;
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<CardImportDto>), new XmlRootAttribute("Cards"));
            var cardDtos = (List<CardImportDto>)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var cardsToAdd = new List<CustomerCard>();
            var sb = new StringBuilder();

            foreach (var cardDto in cardDtos)
            {
                if (!IsValid(cardDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CardType type = CardType.Normal;

                if (cardDto.CardType != null)
                {
                    type = Enum.Parse<CardType>(cardDto.CardType);
                }

                var card = new CustomerCard
                {
                    Name = cardDto.Name,
                    Age = cardDto.Age,
                    Type = type
                };

                cardsToAdd.Add(card);
                sb.AppendLine(string.Format(SuccessMessage, card.Name));
            }

            context.Cards.AddRange(cardsToAdd);
            context.SaveChanges();

            var result = sb.ToString().Trim();
            return result;
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(List<TicketImportDto>), new XmlRootAttribute("Tickets"));
            var ticketDtos = (List<TicketImportDto>)serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));
            var ticketsToAdd = new List<Ticket>();
            var sb = new StringBuilder();

            foreach (var ticketDto in ticketDtos)
            {
                if (!IsValid(ticketDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var departureTime = DateTime.ParseExact(ticketDto.Trip.DepartureTime, "dd/MM/yyyy HH:mm",
                    CultureInfo.InvariantCulture);
                var trip = context.Trips
                    .SingleOrDefault(tr => tr.DestinationStation.Name == ticketDto.Trip.DestinationStation &&
                                           tr.OriginStation.Name == ticketDto.Trip.OriginStation &&
                                           tr.DepartureTime == departureTime);

                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                CustomerCard card = null;

                if (ticketDto.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == ticketDto.Card.Name);
                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }

                var seatingClassAbbreviation = ticketDto.Seat.Substring(0, 2);
                var quantity = int.Parse(ticketDto.Seat.Substring(2));

                var seatExists = trip.Train.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == seatingClassAbbreviation && quantity <= s.Quantity);
                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seat = ticketDto.Seat;

                var ticket = new Ticket
                {
                    Price = ticketDto.Price,
                    SeatingPlace = seat,
                    Trip = trip,
                    CustomerCard = card
                };

                ticketsToAdd.Add(ticket);
                sb.AppendLine(
                    $"Ticket from {ticket.Trip.OriginStation.Name} to {ticket.Trip.DestinationStation.Name} " +
                    $"departing at {ticket.Trip.DepartureTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture)} imported.");
            }

            context.Tickets.AddRange(ticketsToAdd);
            context.SaveChanges();

            var result = sb.ToString().Trim();
            return result;
        }

        private static bool IsValid(object obj)
        {
            var validationContext = new ValidationContext(obj);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(obj, validationContext, validationResults, true);
            return isValid;
        }
    }
}