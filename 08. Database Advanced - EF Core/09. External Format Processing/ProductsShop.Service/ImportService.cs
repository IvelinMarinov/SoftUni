using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductsShop.Models;
using ProductsShop.Models.DTOs;
using ProductShop.Data;

namespace ProductsShop.Service
{
    public class ImportService
    {
        private readonly ProductShopDbContext context;

        public ImportService()
        {
            this.context = new ProductShopDbContext();
        }
        
        public void AddUsers(List<UserDto> userDtos)
        {
            IList<User> users = Mapper.Map<List<User>>(userDtos);

            this.context.Users.AddRange(users);
            this.context.SaveChanges();
        }

        public void AddCategories(List<CategoryDto> categoryDtos)
        {
            IList<Category> categories = Mapper.Map<List<Category>>(categoryDtos);

            this.context.Categories.AddRange(categories);
            this.context.SaveChanges();
        }

        public void AddProducts(List<ProductDto> productDtos)
        {
            IList<Product> products = Mapper.Map<List<Product>>(productDtos);

            List<int> existingUserIds = this.context.Users
                .AsNoTracking()
                .Select(u => u.Id)
                .ToList();

            List<int> existingCategoryIds = this.context.Categories
                .AsNoTracking()
                .Select(c => c.Id)
                .ToList();

            var random = new Random();

            foreach (var product in products)
            {
                product.BuyerId = random.Next(0, existingUserIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault());
                product.SellerId = existingUserIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault();
                product.CategoryProducts.Add(new CategoryProduct
                {
                    ProductId = product.Id,
                    CategoryId = existingCategoryIds.OrderBy(x => Guid.NewGuid()).FirstOrDefault()
                });
            }

            foreach (var product in products)
            {
                if (product.BuyerId == 0)
                {
                    product.BuyerId = null;
                }
            }

            this.context.Products.AddRange(products);
            this.context.SaveChanges();
        }
    }
}
