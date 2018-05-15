using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stations.DataProcessor.Dto
{
    public class TrainImportDto
    {
        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public string Type { get; set; } = "HighSpeed";

        public ICollection<TrainSeatImportDto> Seats { get; set; } = new List<TrainSeatImportDto>();
    }
}
