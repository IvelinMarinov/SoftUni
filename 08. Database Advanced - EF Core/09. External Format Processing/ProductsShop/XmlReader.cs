using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ProductsShop.Models.DTOs;
using ProductsShop.Service;

namespace ProductsShop.App
{
    public class XmlReader
    {
        private ImportService service;

        public XmlReader()
        {
            this.service = new ImportService();
        }

        public void Import()
        {
            Console.WriteLine("XML import summary:");

            ImportUsers();
            ImportCategories();
            ImportProducts();
        }

        private void ImportUsers()
        {
            var xml = XDocument.Load("Resources/users.xml");
            var userStrings = xml.Root.Elements();
            var userDtos = new List<UserDto>();

            foreach (var user in userStrings)
            {
                int? age = null;

                if (user.Attribute("age") != null)
                {
                    age = int.Parse(user.Attribute("age").Value);
                }

                userDtos.Add(new UserDto
                {
                    FirstName = user.Attribute("firstName")?.Value,
                    LastName = user.Attribute("lastName").Value,
                    Age = age
               });
            }

            this.service.AddUsers(userDtos);

            Console.WriteLine($"  {userDtos.Count} users added to database");
        }

        private void ImportCategories()
        {
            var xml = XDocument.Load("Resources/categories.xml");
            var categoryStrings = xml.Root.Elements();
            var categoryDtos = new List<CategoryDto>();

            foreach (var category in categoryStrings)
            {
                categoryDtos.Add(new CategoryDto
                {
                   Name = category.Element("name").Value
                });
            }

            this.service.AddCategories(categoryDtos);

            Console.WriteLine($"  {categoryDtos.Count} categories added to database");
        }

        private void ImportProducts()
        {
            var xml = XDocument.Load("Resources/products.xml");
            var productStrings = xml.Root.Elements();
            var productDtos = new List<ProductDto>();

            foreach (var product in productStrings)
            {
                productDtos.Add(new ProductDto
                {
                    Price = decimal.Parse(product.Element("price").Value),
                    Name = product.Element("name").Value
                });
            }

            this.service.AddProducts(productDtos);

            Console.WriteLine($"  {productDtos.Count} products added to database");
        }
    }
}
