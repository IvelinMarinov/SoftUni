using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProductsShop.Models.DTOs;
using ProductsShop.Service;

namespace ProductsShop.App
{
    public class JsonReader
    {
        private ImportService service;

        public JsonReader()
        {
            this.service = new ImportService();
        }

        public void Read()
        {
            Console.WriteLine("JSON import summary:");

            ImportUsers();
            ImportCategories();
            ImportProducts();
        }

        private void ImportUsers()
        {
            string UsersString = File.ReadAllText("Resources/users.json");

            List<UserDto> userDtos = JsonConvert.DeserializeObject<List<UserDto>>(UsersString);

            this.service.AddUsers(userDtos);

            Console.WriteLine($"  {userDtos.Count} users added to database");
        }

        private void ImportCategories()
        {
            string categoriesString = File.ReadAllText("Resources/categories.json");

            List<CategoryDto> categoryDtos = JsonConvert.DeserializeObject<List<CategoryDto>>(categoriesString);

            this.service.AddCategories(categoryDtos);

            Console.WriteLine($"  {categoryDtos.Count} categories added to database");
        }

        private void ImportProducts()
        {
            string productsString = File.ReadAllText("Resources/products.json");

            List<ProductDto> productDtos = JsonConvert.DeserializeObject<List<ProductDto>>(productsString);

            this.service.AddProducts(productDtos);

            Console.WriteLine($"  {productDtos.Count} products added to database");
        }
    }
}
