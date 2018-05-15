using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProductsShop.Models.DTOs
{
    public class UserWithSoldProductsCount
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("soldProducts")]
        public IList<ProductDto> ProductsSold { get; set; } = new List<ProductDto>();
    }
}
