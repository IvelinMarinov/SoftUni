using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Ticket")]
    public class TicketExportDto
    {
        [XmlElement("OriginStation")]
        public string OriginStation { get; set; }

        [XmlElement("DestinationStation")]
        public string DestinationStation { get; set; }

        [XmlElement("DepartureTime")]
        public string DepartureTime { get; set; }
    }
}
