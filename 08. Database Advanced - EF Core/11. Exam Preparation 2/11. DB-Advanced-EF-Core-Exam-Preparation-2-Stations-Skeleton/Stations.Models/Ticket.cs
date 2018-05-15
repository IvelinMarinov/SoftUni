using System;
using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Range(0.0, Double.MaxValue)]
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        public string SeatingPlace { get; set; }

        public int TripId { get; set; }

        [Required]
        public Trip Trip { get; set; }

        public int? CustomerCardId { get; set; }
        public CustomerCard CustomerCard { get; set; }
    }
}
