using Newtonsoft.Json;

namespace ProductsShop.Models.DTOs
{
    public class ProductWithSellerFullNameDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerName { get; set; }
    }
}
