using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FastFood.DataProcessor.Dto.Import
{
    public class PositionImportDto
    {
        [StringLength(30, MinimumLength = 3)]
        [Required]
        [JsonProperty("Position")]
        public string Name { get; set; }
    }
}
