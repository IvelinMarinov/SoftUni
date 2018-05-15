using System.Collections.Generic;

namespace ProductsShop.Models.DTOs
{
    public class UserWithCountDto
    {
        public int UsersCount { get; set; }

        public IList<UserWithSoldProductsCount> Users { get; set; }
    }
}
