using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using ProductsShop.Models.DTOs;
using ProductShop.Data;

namespace ProductsShop.Service
{
    public class ExportService
    {
        private readonly ProductShopDbContext context;

        public ExportService()
        {
            this.context = new ProductShopDbContext();
        }

        #region Export

        public IList<ProductWithSellerFullNameDto> GetProductsWithSellerInfoInRange(decimal priceFrom, decimal priceTo)
        {
            var productDtos = this.context.Products
                .Where(p => p.Price >= priceFrom && p.Price <= priceTo)
                .ProjectTo<ProductWithSellerFullNameDto>()
                .OrderBy(p => p.Price)
                .ToList();

            return productDtos;
        }

        public IList<UserWithSoldProductsAndBuyerInfoDto> GetUsersWithSoldProductsAndBuyerInfo()
        {
            var userDtos = this.context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .ProjectTo<UserWithSoldProductsAndBuyerInfoDto>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            return userDtos;
        }

        public IList<CategoryByProductDto> GetCategoriesByProduct()
        {
            var categoryDtos = this.context.Categories
                .ProjectTo<CategoryByProductDto>()
                .OrderBy(c => c.Name)
                .ToList();

            return categoryDtos;
        }

        public IList<UserWithSoldProductsCount> GetUsersWithSoldProductsCount()
        {
            var userDtos = this.context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .ProjectTo<UserWithSoldProductsCount>()
                .OrderByDescending(u => u.ProductsSold.Count)
                .ThenBy(u => u.LastName)
                .ToList();

            return userDtos;
        }

        public IList<ProductWithBuyerFullName> GetProductsWithBuyerInfoInRange(decimal priceFrom, decimal priceTo)
        {
            var productDtos = this.context.Products
                .Where(p => p.Price >= priceFrom && p.Price <= priceTo)
                .ProjectTo<ProductWithBuyerFullName>()
                .OrderBy(p => p.Price)
                .ToList();

            return productDtos;
        }

        public IList<UserWithSoldProducts> GetUsersWithSoldProducts()
        {
            var userDtos = this.context.Users
                .Where(u => u.ProductsSold.Any(ps => ps.BuyerId != null))
                .ProjectTo<UserWithSoldProducts>()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ToList();

            return userDtos;
        }

        #endregion
    }
}
