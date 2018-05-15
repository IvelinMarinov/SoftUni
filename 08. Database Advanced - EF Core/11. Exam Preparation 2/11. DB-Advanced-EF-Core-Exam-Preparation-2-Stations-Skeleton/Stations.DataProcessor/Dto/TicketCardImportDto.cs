using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto
{
    [XmlType("Card")]
    public class TicketCardImportDto
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
