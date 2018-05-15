using System.Collections.Generic;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Card")]
    public class CardExportDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }

        public IEnumerable<TicketExportDto> TicketsBought { get; set; }
    }
}
