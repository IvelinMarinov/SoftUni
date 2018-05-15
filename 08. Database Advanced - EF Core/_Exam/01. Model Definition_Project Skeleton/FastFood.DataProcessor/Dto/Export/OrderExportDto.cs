using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Export
{
    public class OrderExportDto
    {
        [JsonProperty("Customer")]
        public string CustomerName { get; set; }

        [JsonProperty("Items")]
        public ICollection<ItemExportDto> Items { get; set; } = new List<ItemExportDto>();

        public decimal TotalPrice { get; set; }
    }
}
