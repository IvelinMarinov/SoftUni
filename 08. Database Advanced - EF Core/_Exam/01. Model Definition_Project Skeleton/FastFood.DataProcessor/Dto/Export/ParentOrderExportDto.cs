using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Export
{
    public class ParentOrderExportDto
    {
        [JsonProperty("Name")]
        public string EmployeeName { get; set; }

        [JsonProperty("Orders")]
        public ICollection<OrderExportDto> Orders { get; set; } = new List<OrderExportDto>();

        public decimal TotalMade { get; set; }
    }
}
