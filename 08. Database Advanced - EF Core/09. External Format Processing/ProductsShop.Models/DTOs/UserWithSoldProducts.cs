using System.Collections.Generic;

namespace ProductsShop.Models.DTOs
{
    public class UserWithSoldProducts
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public ICollection<ProductDto> ProductsSold { get; set; } = new List<ProductDto>();
    }
}
