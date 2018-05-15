using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductsShop.Models.DTOs
{
    public class UserWithSoldProductsAndBuyerInfoDto
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("soldProducts")]
        public ICollection<ProductWithBuyerFirstAndLastNameDto> ProductsSold { get; set; } = new List<ProductWithBuyerFirstAndLastNameDto>();
    }
}
