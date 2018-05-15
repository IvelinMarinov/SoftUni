using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class OrderItemImportDto
    {
        [XmlElement("Name")]
        public string ItemName { get; set; }

        [XmlElement("Quantity")]
        public int Quantity { get; set; }
    }
}
