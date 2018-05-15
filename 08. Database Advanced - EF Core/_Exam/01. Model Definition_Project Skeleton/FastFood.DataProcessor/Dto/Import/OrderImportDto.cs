using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using FastFood.Models.Enums;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Order")]
    public class OrderImportDto
    {
        [Required]
        [XmlElement("Customer")]
        public string CustomerName { get; set; }

        [Required]
        [XmlElement("Employee")]
        public string EmployeeName { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public OrderType Type { get; set; } = OrderType.ForHere;

        [XmlElement("Items")]
        public ICollection<OrderItemImportDto> Items { get; set; } = new List<OrderItemImportDto>();
    }
}
