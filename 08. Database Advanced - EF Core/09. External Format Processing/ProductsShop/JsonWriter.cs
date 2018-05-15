using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProductsShop.Models.DTOs;
using ProductsShop.Service;

namespace ProductsShop.App
{
    public class JsonWriter
    {
        private ExportService service;

        public JsonWriter()
        {
            this.service = new ExportService();
        }

        public void Write()
        {
            GetProductsInRange();
            GetUsersWithSuccessfullySoldProducts();
            GetCategoriesByProduct();
            GetUsersWithProductsSoldCount();
            Console.WriteLine("XML data exported successfully");
        }

        private void GetProductsInRange()
        {
            var priceFrom = 500m;
            var priceTo = 1000m;

            var productDtos = this.service.GetProductsWithSellerInfoInRange(priceFrom, priceTo);

            var productsAsJson = JsonConvert.SerializeObject(productDtos, Formatting.Indented);
            
            File.WriteAllText("Output/products-in-range.json", productsAsJson);
        }

        private void GetUsersWithSuccessfullySoldProducts()
        {
            var userDtos = this.service.GetUsersWithSoldProductsAndBuyerInfo();

            var productsAsJson = JsonConvert.SerializeObject(userDtos, Formatting.Indented, 
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText("Output/users-sold-products.json", productsAsJson);
        }

        private void GetCategoriesByProduct()
        {
            var categoryDtos = this.service.GetCategoriesByProduct();

            var categoriesAsJson = JsonConvert.SerializeObject(categoryDtos, Formatting.Indented,
                new JsonSerializerSettings
                {
                    DefaultValueHandling = DefaultValueHandling.Ignore
                });

            File.WriteAllText("Output/categories-by-products.json", categoriesAsJson);
        }

        private void GetUsersWithProductsSoldCount()
        {
            var userDtos = this.service.GetUsersWithSoldProductsCount();

            var usersCount = userDtos.Count;

            var userModifiedDtos = new UserWithCountDto
            {
                UsersCount = userDtos.Count,
                Users = userDtos
            };
           
            var usersAsJson = JsonConvert.SerializeObject(userModifiedDtos, Formatting.Indented);

            File.WriteAllText("Output/users-and-products.json", usersAsJson);
        }
    }
}