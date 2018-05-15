using Newtonsoft.Json;
using System.Xml.Serialization;

namespace ProductsShop.Models.DTOs
{
    public class CategoryByProductDto
    {
        [JsonProperty("category")]
        [XmlAttribute("name")]
        public string Name { get; set; }

        [JsonProperty("productsCount")]
        [XmlElement("products-count")]
        public int ProductsCount { get; set; }

        [JsonProperty("averagePrice")]
        [XmlElement("average-price")]
        public decimal AveragePrice { get; set; }

        [JsonProperty("totalRevenue")]
        [XmlElement("total-revenue")]
        public decimal TotalRevenue { get; set; }
    }
}
